using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SampleData sample = new SampleData();
        sample.name = "Peter";
        sample.score = 10.0f;

        string data = JsonUtility.ToJson(sample);
        Debug.Log($"Data: {data}");

    }

}
