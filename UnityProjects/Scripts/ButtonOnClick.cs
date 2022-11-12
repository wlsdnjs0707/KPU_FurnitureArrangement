using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnClick : MonoBehaviour
{
    // Quit ¹öÆ°
    public void OnClickExit()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
