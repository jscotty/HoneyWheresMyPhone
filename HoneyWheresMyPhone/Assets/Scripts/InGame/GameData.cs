using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    public Direction direction;
}

public enum Direction
{
    UP,
    DOWN,
    NONE
}