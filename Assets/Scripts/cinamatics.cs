using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cinamatics : MonoBehaviour
{
    public Camera incam;
    public Camera mainCam;
    public introcam intro;
    public Canvas xhair;
    
    void Start()
    {
        
        incam.enabled = true;
        mainCam.enabled = false;
        xhair.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {


        
        if (intro.finished)
		{
            mainCam.enabled = true;
            incam.enabled = false;
            xhair.enabled = true;
        }
    }
}
