using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSample", menuName = "CircuitStream/Sample Scriptable Object", order = 1)]
public class SOExample : ScriptableObject
{
    public string objName;
    public string score;
    public Vector2 startPos;
}
