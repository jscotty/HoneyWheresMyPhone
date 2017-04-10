using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBase : MonoBehaviour
{

    [SerializeField]
    private int _score;
    [SerializeField]
    private bool _endObject;
    public int itemIndexForSpawning;

    /// <summary>
    /// Returns the score of the item
    /// </summary>
    /// <returns></returns>
    public int Score()
    {
        return _score;
    }

    /// <summary>
    /// Returns if the object is an end object
    /// </summary>
    /// <returns></returns>
    public bool EndObject()
    {
        return _endObject;
    }
}
