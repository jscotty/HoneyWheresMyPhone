using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public Direction direction;
    public float endItemDepth;
}

public enum Direction
{
    UP,
    DOWN,
    NONE
}