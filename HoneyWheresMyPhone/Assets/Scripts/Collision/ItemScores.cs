using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScores : MonoBehaviour {

    [SerializeField] private int _score;
    [SerializeField] private bool _endObject;

    /// <summary>
    /// Returns the score of the item
    /// </summary>
    /// <returns></returns>
    public int Score() {
        return _score;
    }

    /// <summary>
    /// Returns if the object is an end object
    /// </summary>
    /// <returns></returns>
    public bool AquiredEndObject() {
        return _endObject;
    }
}
