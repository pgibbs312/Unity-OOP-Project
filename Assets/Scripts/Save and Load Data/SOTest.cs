using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOTest : MonoBehaviour
{
    public SOExample sample;

    void Start()
    {
        if (!sample)
        {
            return;
        } else 
        {
            Debug.Log($"Scriptable object: {sample}");
        }
    }
}
