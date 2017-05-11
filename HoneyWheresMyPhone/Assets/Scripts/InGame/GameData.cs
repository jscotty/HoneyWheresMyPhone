using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Direction direction;
    public float endItemDepth
    {
        get
        {
            return PlayerPrefs.GetInt("MaxDepth")*200 -2; //the -2 is so the phone is high up enough that you can actally pick it up
        }
    }
}

public enum Direction
{
    UP,
    DOWN,
    NONE,
    HEADSTART
}