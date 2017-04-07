using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScores : MonoBehaviour {

    [SerializeField] private int _score;
    [SerializeField] private bool _endObject;

    public int Score() {
        return _score;
    }

    public bool AquiredEndObject() {
        return _endObject;
    }
}
