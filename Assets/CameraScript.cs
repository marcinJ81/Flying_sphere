using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Camera mainCam;
    public Camera secondCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetEnabledCamera(KeyCode.Alpha1,true, false);
        SetEnabledCamera(KeyCode.Alpha2, false, true);
        
    }
    private void SetEnabledCamera(KeyCode key, bool MainCam, bool SecondCam)
    {
        if (Input.GetKeyDown(key))
        {
            mainCam.enabled = MainCam;
            secondCam.enabled = SecondCam;
        }
    }
}

