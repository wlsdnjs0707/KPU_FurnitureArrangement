using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotateLeft : MonoBehaviour
{
    public bool isButtonDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isButtonDown)
        {
            ARPlaceOnPlane.spawnObject.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
    }
    public void PointerDown()
    {
        isButtonDown = true;
    }
    public void PointerUp()
    {
        isButtonDown = false;
    }
}
