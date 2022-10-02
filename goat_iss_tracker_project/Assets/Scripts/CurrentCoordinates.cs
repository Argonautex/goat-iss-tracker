using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentCoordinates : MonoBehaviour
{
    float major;
    float minor;
    float n;
    [SerializeField] Transform planet;
    Vector3 new_coords;
    Vector3 old_coords = new Vector3(0, 0, 0);
    float deltaTime = 0f;
    float clock = 0f;

    // Start is called before the first frame update
    void Start()
    {
        major = 6371f;
        minor = 6371f;
    }

    // Update is called once per frame
    void Update()
    {
        // Get current position
        float alt = ApiData.data.altitude;
        float lon = ApiData.data.longitude * Mathf.Deg2Rad;
        float lat = ApiData.data.latitude * Mathf.Deg2Rad;



        Vector3 temp = new_coords;
        new_coords = latlon2ecef(lon, lat, alt);

        new_coords = Vector3.Scale(new_coords, planet.localScale) / 100f / 6371f + planet.localPosition;
        deltaTime = Time.deltaTime;
        if (temp != new_coords)
        {
            old_coords = temp;
            clock = 0;
        }
        else
        {
            clock += deltaTime;
            if (clock > 1)
            {
                clock = 1f;
            }
        }
        transform.position = Vector3.Lerp(old_coords, new_coords, clock);
        transform.LookAt(planet.transform.position);
    }

    public Vector3 latlon2ecef(float lon, float lat, float alt)
    {
        n = Mathf.Pow(major, 2) / Mathf.Sqrt(Mathf.Pow(major, 2) * Mathf.Pow(Mathf.Cos(lat), 2) + Mathf.Pow(minor, 2) * Mathf.Pow(Mathf.Sin(lat), 2));
        float x = (n + alt) * Mathf.Cos(lat) * Mathf.Cos(lon);
        float z = (n + alt) * Mathf.Cos(lat) * Mathf.Sin(lon);
        float y = (n * Mathf.Pow((minor / major), 2) + alt) * Mathf.Sin(lat);

        return new Vector3(x, y, z);
    }
}
