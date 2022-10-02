using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom_camera : MonoBehaviour
{
    // Declare variables
    private Camera main_camera;
    [SerializeField] Transform planet;
    private float zoom_speed = 20.0f;
    private float rotation_speed = 5.0f;
    private float min_zoom_dist = 2.0f;
    private float max_zoom_dist = 100.0f;
    void Start()
    {
        main_camera = Camera.main;
    }

    void Update()
    {

        /* if button is pressed the camera rotate around the planet
        depending on the axis of the mouse*/
        if (Input.GetMouseButton(0))
        {
            main_camera.transform.RotateAround(planet.transform.position,
                                                    main_camera.transform.up,
                                                    Input.GetAxis("Mouse X") * rotation_speed);
            main_camera.transform.RotateAround(planet.transform.position,
                                                    main_camera.transform.right,
                                                    -Input.GetAxis("Mouse Y") * rotation_speed);
        }

        // Zoom of the camera within a range of values
        main_camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom_speed;

        if (main_camera.fieldOfView < min_zoom_dist){
            main_camera.fieldOfView = min_zoom_dist;
        }
        if (main_camera.fieldOfView > max_zoom_dist){
            main_camera.fieldOfView = max_zoom_dist;
        }
       
        // We focus the earth
        main_camera.transform.LookAt(planet.position);
        
    }
}
