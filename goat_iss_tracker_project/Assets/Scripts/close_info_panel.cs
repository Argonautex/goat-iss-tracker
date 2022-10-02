using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_info_panel : MonoBehaviour
{
    // Declare variables
    Animator animator;
    public focus a;
    [SerializeField] Camera iss_cam;

    void Start()
    {
        // a is the object from the class focus
        a = FindObjectOfType<focus>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // if mouse button is pressed the info tab closes
        if ((iss_cam.enabled == false)){
            a.pressed = false;
            animator.ResetTrigger("open");
            animator.SetTrigger("close");
        }else
        {
            animator.ResetTrigger("close");
            animator.SetTrigger("open");
        }
    }
}
