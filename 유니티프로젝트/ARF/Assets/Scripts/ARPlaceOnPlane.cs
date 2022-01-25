using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARPlaceOnPlane : MonoBehaviour
{

    public ARRaycastManager arRaycaster;
    public GameObject placeObject;

    GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        UpdateCenterObject();
    }

    // Update is called once per frame
    void Update()
    {
        // 터치없이 계속 변경되게
        // UpdateCenterObject();

        // 터치 시 위치 업데이트
        PlaceObjectByTouch();
    }

    private void PlaceObjectByTouch()
    {
        if(Input.touchCount>0) // 터치가 발생하면
        {
            Touch touch = Input.GetTouch(0); // 첫 터치가 발생한 위치(0번째)

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            if (arRaycaster.Raycast(touch.position, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if(!spawnObject) // spawnObject가 Null이면
                {
                    // 인스턴스화하여 spawnObject에 저장
                    spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                }
                else
                {
                    // position과 rotation 업데이트
                    spawnObject.transform.position = hitPose.position;
                    spawnObject.transform.rotation = hitPose.rotation;
                }
                
            }
        }
    }

    private void UpdateCenterObject()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f)); // 카메라 screen의 센터 받아옴
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        arRaycaster.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
    
        if(hits.Count>0)
        {
            Pose placementPose = hits[0].pose;
            placeObject.SetActive(true);
            placeObject.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placeObject.SetActive(false);
        }
    }
}
