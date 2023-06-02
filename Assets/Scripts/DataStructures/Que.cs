using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Que : MonoBehaviour
{
    public GameObject testPrefab;
    public Queue<GameObject> queue = new Queue<GameObject>();
    GameObject tempObj;
    Vector2 lastInQueuedPosition = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            tempObj = Instantiate(testPrefab, transform);
            tempObj.transform.position = new Vector2(lastInQueuedPosition.x + 1, 0);

            tempObj.name = $"QUED {queue.Count}";
            tempObj.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            queue.Enqueue(tempObj); // add a item to the queue
            lastInQueuedPosition = tempObj.transform.position;

            Debug.Log($"Enqueued {tempObj.name}");
        }
    }
}
