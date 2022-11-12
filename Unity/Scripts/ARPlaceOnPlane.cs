using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARPlaceOnPlane : MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public ARPlaneManager arPlaneManager;
    public GameObject placeObject;
    public static GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectByTouch();

    }

    private void PlaceObjectByTouch()
    {
        arPlaneManager = GameObject.Find("AR Session Origin").GetComponent<ARPlaneManager>();

        if (Input.GetTouch(0).position[1] > 700) // 버튼 UI 보다 위에만 객체 생성 가능
        {
            if (Input.touchCount > 0) // 터치 발생 시
            {
                Touch touch = Input.GetTouch(0); // 첫 터치 위치

                List<ARRaycastHit> hits = new List<ARRaycastHit>();

                if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
                {
                    Pose hitPose = hits[0].pose;

                    if (!spawnObject)
                    {
                        spawnObject = Instantiate(placeObject, hitPose.position, hitPose.rotation);
                    }
                    else
                    {

                        if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.Vertical)
                        {
                            //pass
                        }
                        else if (arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalUp || arPlaneManager.GetPlane(hits[0].trackableId).alignment == PlaneAlignment.HorizontalDown)
                        {
                            spawnObject.transform.rotation = hitPose.rotation;
                            spawnObject.transform.position = hitPose.position;
                        }
                    }
                }
            }
        }

    }

    private void UpdateCenterObject() // 객체 자동 이동
    {

        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));

        List<ARRaycastHit> hits = new List<ARRaycastHit>();

        arRaycaster.Raycast(screenCenter, hits, TrackableType.Planes);

        if (hits.Count > 0)
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

    public void SelectOfficeChair()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 오피스체어로 변경
        GameObject officeChair = Resources.Load<GameObject>("OfficeChair");
        if (officeChair != null)
        {
            spawnObject = Instantiate(officeChair);
        }

        spawnObject.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        
    }

    public void SelectNaturalDrawer()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 내츄럴 드로어로 변경
        GameObject naturalDrawer = Resources.Load<GameObject>("NaturalDrawer");
        if (naturalDrawer != null)
        {
            spawnObject = Instantiate(naturalDrawer);
        }

        spawnObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

    }

    public void SelectModernChair()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 모던 체어로 변경
        GameObject modernChair = Resources.Load<GameObject>("ModernChair");
        if (modernChair != null)
        {
            spawnObject = Instantiate(modernChair);
        }

        spawnObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

    }

    public void SelectModernTable()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 모던 테이블로 변경
        GameObject modernTable = Resources.Load<GameObject>("ModernTable");
        if (modernTable != null)
        {
            spawnObject = Instantiate(modernTable);
        }

        spawnObject.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

    }

    public void SelectNaturalTable()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 내츄럴 테이블로 변경
        GameObject naturalTable = Resources.Load<GameObject>("NaturalTable");
        if (naturalTable != null)
        {
            spawnObject = Instantiate(naturalTable);
        }

        spawnObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);

    }
    public void SelectNaturalChair()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 내츄럴 체어로 변경
        GameObject naturalChair = Resources.Load<GameObject>("NaturalChair");
        if (naturalChair != null)
        {
            spawnObject = Instantiate(naturalChair);
        }

        spawnObject.transform.localScale = new Vector3(2f, 2f, 2f);

    }

    public void SelectClassicChair()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 클래식 체어로 변경
        GameObject classicChair = Resources.Load<GameObject>("ClassicChair");
        if (classicChair != null)
        {
            spawnObject = Instantiate(classicChair);
        }

        spawnObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

    }
    public void SelectClassicSofa()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 클래식 소파로 변경
        GameObject classicSofa = Resources.Load<GameObject>("ClassicSofa");
        if (classicSofa != null)
        {
            spawnObject = Instantiate(classicSofa);
        }

        spawnObject.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

    }
    public void SelectClassicTable()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 클래식 테이블로 변경
        GameObject classicTable = Resources.Load<GameObject>("ClassicTable");
        if (classicTable != null)
        {
            spawnObject = Instantiate(classicTable);
        }

        spawnObject.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);

    }
    public void SelectCasualTable()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 캐주얼 테이블로 변경
        GameObject casualTable = Resources.Load<GameObject>("CasualTable");
        if (casualTable != null)
        {
            spawnObject = Instantiate(casualTable);
        }

        spawnObject.transform.localScale = new Vector3(5f, 5f, 5f);

    }
    public void SelectCasualChair()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 캐주얼 체어로 변경
        GameObject casualChair = Resources.Load<GameObject>("CasualChair");
        if (casualChair != null)
        {
            spawnObject = Instantiate(casualChair);
        }

        spawnObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

    }
    public void SelectCasualSofa()
    {
        // 원래 생성한 객체 제거
        Destroy(spawnObject);

        // 생성할 객체 캐주얼 소파로 변경
        GameObject casualSofa = Resources.Load<GameObject>("CasualSofa");
        if (casualSofa != null)
        {
            spawnObject = Instantiate(casualSofa);
        }

        spawnObject.transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

    }
}
