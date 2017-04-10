using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{

    Direction direction;
}

public enum Direction
{
    UP,
    DOWN
}