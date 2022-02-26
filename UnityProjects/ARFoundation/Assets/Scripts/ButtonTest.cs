using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTest : MonoBehaviour
{
    // Test 버튼
    public void OnClickTest()
    {
        // 원래 생성한 객체 제거
        Destroy(ARPlaceOnPlane.spawnObject);

        // 큐브(테스트)로 생성할 객체 변경
        ARPlaceOnPlane.spawnObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ARPlaceOnPlane.spawnObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
    }

    // Quit 버튼
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
