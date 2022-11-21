using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoomer : MonoBehaviour
{
    public float zoomLevel_starting = 5;
    public float zoomLevel_min = 3;
    public float zoomLevel_max = 18;
    protected float zoomLevel_current;
    protected float zoomLevel_target;
    public Camera cameraMain;
    // Start is called before the first frame update
    void Start()
    {
        cameraMain = GetComponent<Camera>();
        zoomLevel_current = zoomLevel_starting;
        zoomLevel_target = zoomLevel_starting;
        
        InputHandler.ACT_ZoomControl += ZoomControl;

    }

    // Update is called once per frame
    void Update()
    {
        zoomLevel_current = cameraMain.orthographicSize;
    }

    void FixedUpdate()
    {
        if(zoomLevel_target > zoomLevel_max){zoomLevel_target = zoomLevel_max;}
        if(zoomLevel_target < zoomLevel_min){zoomLevel_target = zoomLevel_min;}
        cameraMain.orthographicSize = zoomLevel_target;
    }

    void ZoomControl(float ZoomAmount)
    {
        
        zoomLevel_target = zoomLevel_target + ZoomAmount;
    }
}
