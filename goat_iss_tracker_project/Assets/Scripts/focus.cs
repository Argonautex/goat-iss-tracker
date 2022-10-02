using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class focus : MonoBehaviour
{
    [SerializeField] Transform iss;
    [SerializeField] Transform planet;
    [SerializeField] Camera camara_iss;
    public Camera main_cam;
    public bool pressed = false;
    private Vector3 velocity = Vector3.zero;

    public void OnButtonPress()
    {
        pressed = true;
        camara_iss.transform.position = iss.transform.TransformPoint(0, 0, -3);
        if (camara_iss.enabled == true){
            camara_iss.enabled = false;
            main_cam.enabled = true;
            iss.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
        }else{
            camara_iss.enabled = true;
            main_cam.enabled = false;
            iss.localScale = new Vector3 (0.02f, 0.02f, 0.02f);
        }
        camara_iss.fieldOfView = 100;
    }

    void Start()
    {
        main_cam = Camera.main;
        main_cam.enabled = true;
        camara_iss.enabled = false;
    }

    void Update()
    {
    }
}
