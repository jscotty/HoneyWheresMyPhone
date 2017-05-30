using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {

    [SerializeField]
    private float _rotationSpeed = 3;
    private GameData _gameData;
    private Transform _hand;

    /// <summary>
    /// sets the needed references
    /// </summary>
    private void Start()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        _hand = HookCollision.handTransform;
    }

    /// <summary>
    /// rotates the items over time
    /// </summary>
    private void FixedUpdate()
    {
        if (_hand.position.x < transform.position.x)
        {
            if (_gameData.direction == Direction.DOWN)
            {
                transform.Rotate(new Vector3(0, 0, -Time.fixedDeltaTime * _rotationSpeed));
            }
            else if (_gameData.direction == Direction.UP)
            {
                transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * _rotationSpeed));
            }
            else if (_gameData.direction == Direction.HEADSTART)
            {
                transform.Rotate(new Vector3(0, 0, -Time.fixedDeltaTime * 4 * _rotationSpeed));
            }
        }
        else
        {
            if (_gameData.direction == Direction.DOWN)
            {
                transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * _rotationSpeed));
            }
            else if (_gameData.direction == Direction.UP)
            {
                transform.Rotate(new Vector3(0, 0, -Time.fixedDeltaTime * _rotationSpeed));
            }
            else if (_gameData.direction == Direction.HEADSTART)
            {
                transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * 4 * _rotationSpeed));
            }
        }
    }
}
