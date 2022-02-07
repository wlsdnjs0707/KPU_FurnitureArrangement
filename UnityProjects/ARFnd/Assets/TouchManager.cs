using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TouchManager : MonoBehaviour
{
    //생성할 객체 
    private GameObject placeObject;
    private ARRaycastManager raycastMgr;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private bool Touched = false;
    private GameObject SelectedObj;
    [SerializeField] private Camera arCamera;

    int tcount = 0;

    void Start()
    {

        // 생성할 큐브를 할당
        placeObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // 큐브의 크기를 설정 
        placeObject.transform.localScale = Vector3.one * 0.05f;

        // AR Raycast Manager 추출 
        raycastMgr = GetComponent<ARRaycastManager>();

    }

    void Update()
    {
        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);

        //터치 시작시
        if (touch.phase == TouchPhase.Began)
        {
            Ray ray;
            RaycastHit hitobj;

            ray = arCamera.ScreenPointToRay(touch.position);

            if(tcount==0)
            {
                if(raycastMgr.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
                {
                    Instantiate(placeObject, hits[0].pose.position, hits[0].pose.rotation);
                    tcount++;
                }
            }

            //Ray를 통한 오브젝트 인식
            if (Physics.Raycast(ray, out hitobj))
            {
                //터치한 곳에 오브젝트 이름이 Cube를 포함하면
                if (hitobj.collider.name.Contains("Cube"))
                {
                    //그 오브젝트를 SelectObj에 놓는다 //터치하고 있는다
                    SelectedObj = hitobj.collider.gameObject;
                    Touched = true;
                }

            }

        }

        //터치가 끝나면 터치 끝.
        if (touch.phase == TouchPhase.Ended)
        {
            Touched = false;
        }

        if (raycastMgr.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            //터치 시 해당 오브젝트 위치 초기화
            if (Touched)
            {
                SelectedObj.transform.position = hits[0].pose.position;
            }
        }
    }
}