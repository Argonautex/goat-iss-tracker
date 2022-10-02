using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class info : MonoBehaviour
{
    [SerializeField] TMP_Text datos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        datos.text = "Altitude = " + ApiData.data.altitude + "km" + "\n" + "\n" + "Latitude = " + ApiData.data.latitude
        + "\n" + "\n" +  "Longitude = " + ApiData.data.longitude + "\n" + "\n" +  "Velocity = " + ApiData.data.velocity + "\n" + "\n"
        + "Visibility = " + ApiData.data.visibility;
    }
}
