using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonExample1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SampleDataComplex sample = new SampleDataComplex();
        sample.name = "Peter";
        sample.address = new Address();
        sample.address.unit = 5;
        sample.address.road = "Test Road";
        sample.address.city = "Vancouver";

        sample.books = new Book[2];
        sample.books[0] = new Book();
        sample.books[0].author = "Peter";
        sample.books[0].name = "Tales";
        sample.books[0].isDigital = true;

        sample.books[1] = new Book();
        sample.books[1].author = "Joe";
        sample.books[1].name = "Doey";
        sample.books[1].isDigital = false;

        string data = JsonUtility.ToJson(sample);
        Debug.Log($"Data: {data}");
    }

}
