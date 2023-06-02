using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExample : MonoBehaviour
{
    public GameObject testPrefab;

    public List<GameObject> list = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObj;
        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(0, 0);
        list.Add(tempObj);
        
        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(1, 0);
        list.Add(tempObj);
        
        tempObj = Instantiate(testPrefab, transform);
        tempObj.transform.position = new Vector2(2, 0);
        list.Add(tempObj);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV();
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject tempObj;
            tempObj = Instantiate(testPrefab, transform);
            tempObj.transform.position = new Vector2(list[list.Count - 1].transform.position.x + 1, 0);
            list.Add(tempObj);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(list[list.Count - 1].gameObject);
            list.RemoveAt(list.Count -1); // Only removes it from the list
        }
    }
}
