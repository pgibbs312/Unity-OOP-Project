using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExamples : MonoBehaviour
{
    public GameObject testPrefab;
    public GameObject[] testArray;
    public int[] testIntArrays;

    public GameObject[] array = new GameObject[2];
    // Start is called before the first frame update
    void Start()
    {
        array[0] = Instantiate(testPrefab, transform);
        array[0].transform.position = new Vector2(0, 0); // set new position for the array 
        array[1] = Instantiate(testPrefab, transform);
        array[1].transform.position = new Vector2(1, 0);   
    }

    // Update is called once per frame
    void Update()
    {
        // Pick random object and change the colour to a random color
        if (Input.GetKeyDown(KeyCode.R))
        {
            array[Random.Range(0, array.Length)].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0)) // Keyboard 0
        {
            Destroy(array[0].gameObject);
            Debug.Log($"Destroyed {array[0].gameObject}");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            array[0] = Instantiate(testPrefab, transform);
            array[0].transform.position = new Vector2(0, 0);
        }
    }
}
