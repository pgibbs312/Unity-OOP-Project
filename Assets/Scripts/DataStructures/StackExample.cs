using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackExample : MonoBehaviour
{
    public GameObject testPrefab;
    public Stack<GameObject> stack = new Stack<GameObject>();
    GameObject tempObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempObject = Instantiate(testPrefab, transform);
            tempObject.transform.position = new Vector2(0, stack.Count);

            tempObject.name = $"STACKED- {stack.Count}";
            tempObject.GetComponent<SpriteRenderer>().color = Random.ColorHSV();

            stack.Push(tempObject);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            var removeObj = stack.Pop();
            Destroy(removeObj);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log($"Object  at the top is {stack.Peek().name}");
        }
    }
}
