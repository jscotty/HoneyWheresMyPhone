using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScores : MonoBehaviour {

    [SerializeField] private int _score;

    public int Score() {
        return _score;
    }
}
