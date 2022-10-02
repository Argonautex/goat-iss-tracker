using UnityEngine;

public class SunPosition : MonoBehaviour
{
    float major;
    float minor;
    float n;
    [SerializeField] Transform planet;
    Vector3 coords;


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
        float lon = ApiData.data.solar_lon * Mathf.Deg2Rad;
        float lat = ApiData.data.solar_lat * Mathf.Deg2Rad;
        float alt = 500000;

        coords = latlon2ecef(lon, lat, alt);

        coords = Vector3.Scale(coords, planet.localScale) / 100f / 6371f + planet.localPosition;

        transform.position = coords;
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


