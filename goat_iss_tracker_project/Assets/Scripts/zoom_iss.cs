using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_iss : MonoBehaviour
{
    // Declare variables
    [SerializeField] Camera iss_camera;
    [SerializeField] Transform iss;
    private float zoom_speed = 20.0f;
    private float rotation_speed = 5.0f;
    private float min_zoom_dist = 5.0f;
    private float max_zoom_dist = 50.0f;
    void Start()
    {
    }

    void Update()
    {

        /* if button is pressed the camera rotate around the planet
        depending on the axis of the mouse*/
        if (Input.GetMouseButton(0))
        {
            iss_camera.transform.RotateAround(iss.transform.position,
                                                    iss_camera.transform.up,
                                                    Input.GetAxis("Mouse X") * rotation_speed);
            iss_camera.transform.RotateAround(iss.transform.position,
                                                    iss_camera.transform.right,
                                                    -Input.GetAxis("Mouse Y") * rotation_speed);
        }

        // Zoom of the camera within a range of values
        iss_camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;

        if (iss_camera.fieldOfView < min_zoom_dist){
            iss_camera.fieldOfView = min_zoom_dist;
        }
        if (iss_camera.fieldOfView > max_zoom_dist){
            iss_camera.fieldOfView = max_zoom_dist;
        }


        //iss_camera.transform.position = Vector3.MoveTowards(iss_camera.transform.position, iss.transform.position, 0.3f);
        // We focus the earth
        iss_camera.transform.LookAt(iss.position);
        
    }
}
