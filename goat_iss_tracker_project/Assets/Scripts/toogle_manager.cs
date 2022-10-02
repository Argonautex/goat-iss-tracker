using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toogle_manager : MonoBehaviour
{
    [SerializeField] Light sol;
    [SerializeField] GameObject panel_info;
    private LensFlare flare;
    private bool sun_on;
    private bool panel_on;
    public void sun(){
        if (sun_on == true){
            flare.enabled = true;
            sun_on = false;
        }
        else{
            flare.enabled = false;
            sun_on = true;
        }
    }
    public void description_info(){
                if (panel_on == true){
            panel_info.SetActive(true);
            panel_on = false;
        }
        else{
            panel_info.SetActive(false);
            panel_on = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        flare = sol.GetComponent<LensFlare>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
