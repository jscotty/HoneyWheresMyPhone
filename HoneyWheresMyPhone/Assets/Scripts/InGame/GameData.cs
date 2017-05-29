using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Direction direction;

    /// <summary>
    /// returns the endItemDepth
    /// </summary>
    public float endItemDepth
    {
        get
        {
            return PlayerPrefs.GetInt("MaxDepth")*200 -2; //the -2 is so the phone is high up enough that you can actally pick it up
        }
    }
}

/// <summary>
/// Enum with values that controlthe mvement of the game
/// </summary>
public enum Direction
{
    UP,
    DOWN,
    NONE,
    HEADSTART
}