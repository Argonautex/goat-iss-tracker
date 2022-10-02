using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_options : MonoBehaviour
{
    public bool boton = false;
    Animator animador2;
    public void opciones_pulsado()
    {
                        if (boton == true){
            animador2.ResetTrigger("open_op");
            animador2.SetTrigger("close_op");
        }
        if (boton == false){
        boton = true;
        }else{
            boton = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        animador2 = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
