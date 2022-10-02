using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiData : MonoBehaviour
{
    public static ISSdataAPI data;
    float clock = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        clock += Time.deltaTime;
        if (clock > 1)
        {
            clock = 0;
            StartCoroutine("ISSapi");
        }
    }

    // Corrutine to get data from the API
    IEnumerator ISSapi()
    {
        string api = "https://api.wheretheiss.at/v1/satellites/25544";
        UnityWebRequest request = UnityWebRequest.Get(api);
        yield return request.SendWebRequest();

        // Error checking
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("There has been an error during the http request.");
        }
        else
        {
            // JSON serializer
            string resultText = request.downloadHandler.text;
            //Debug.Log(request.downloadHandler.text);

            data = JsonUtility.FromJson<ISSdataAPI>(resultText);

            //Debug.Log($"alt: {data.altitude}, lat: {data.latitude}");
        }
    }

    // Class with parameters from JSON
    public class ISSdataAPI
    {
        public float latitude;
        public float longitude;
        public float altitude;
        public float velocity;
        public string visibility;
        public long timestamp;
        public double daynum;
        public float solar_lat;
        public float solar_lon;
    }
}
