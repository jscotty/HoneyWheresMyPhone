using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    private float _rotationSpeed;
    private GameData _gameData;
    private Transform _hand;

    private void Start()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        _hand = HookCollision.handTransform;
    }

    private void FixedUpdate()
    {
        if (_hand.position.x < transform.position.x)
        {
            if (_gameData.direction == Direction.DOWN)
            {
                transform.Rotate(new Vector3(0, 0, -0.1f));
            }
            else if (_gameData.direction == Direction.UP)
            {
                transform.Rotate(new Vector3(0, 0, 0.1f));
            }
            else if (_gameData.direction == Direction.HEADSTART)
            {
                transform.Rotate(new Vector3(0, 0, -0.4f));
            }
        }
        else
        {
            if (_gameData.direction == Direction.DOWN)
            {
                transform.Rotate(new Vector3(0, 0, 0.1f));
            }
            else if (_gameData.direction == Direction.UP)
            {
                transform.Rotate(new Vector3(0, 0, -0.1f));
            }
            else if (_gameData.direction == Direction.HEADSTART)
            {
                transform.Rotate(new Vector3(0, 0, 0.4f));
            }
        }
    }
}
