//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    [SerializeField] private Transform _hand;
    private bool moveHand = true;
    [SerializeField] private float _desiredHandMovement;
    private Vector2 _startPosition;

    [SerializeField] private GameObject _endScreen;
    private bool setDepth = false;

    private float _desiredHandYPosition;

    private GameData _gameData;

    private void Awake()
    {
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();

    }

    private void Start()
    {
        _gameData.direction = Direction.DOWN;
        _desiredHandYPosition = _hand.transform.position.y - _desiredHandMovement;
        _startPosition = (Vector2)transform.position;
    }

    /// <summary>
    /// Moves the objects and moves the hand if the way you're going changed recently
    /// </summary>
    private void FixedUpdate()
    {
        if (_gameData.direction == Direction.UP)
        {
            if (!setDepth)
            {
                ScoreManager.Instance.depthCurrentRound = transform.position.y;
                setDepth = true;
            }
            transform.Translate(Vector2.down * _speed / 20);
            if(transform.position.y <= _startPosition.y)
            {
                _gameData.direction = Direction.NONE;
                _endScreen.SetActive(true);
            }
            if (moveHand)
            {
                _hand.Translate(Vector2.down * _speed / 50);
                if (_hand.position.y <= _desiredHandYPosition)
                {
                    _hand.position = new Vector2(0, _desiredHandYPosition);
                    moveHand = false;
                }
            }
        }
        else if(_gameData.direction == Direction.DOWN)
        {
            transform.Translate(Vector2.up * _speed / 20);
        }
    }
}
