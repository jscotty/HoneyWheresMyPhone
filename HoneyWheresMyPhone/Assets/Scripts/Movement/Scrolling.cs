//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    
    [SerializeField]
    private float _speed;
    [SerializeField]
    private Transform _hand;
    private bool moveHand = true;
    [SerializeField]
    private float _desiredHandMovement;
    private Vector2 _startPosition;

    [SerializeField] private GameObject _endScreen;
    private bool setDepth = false;

    private float _desiredHandYPosition;

    private GameData _gameData;

    private float _headStartTime;

    public float percentage { get; private set; }

    private void Awake()
    {
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        PlayerPrefs.SetInt("HeadStartUpgrade", 1);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("StartDepth") > 1)
        {
            _gameData.direction = Direction.HEADSTART;
        }
        else
        {
            _gameData.direction = Direction.DOWN;
        }
        _desiredHandYPosition = _hand.transform.position.y - _desiredHandMovement;
        _startPosition = (Vector2)transform.position;
    }

    /// <summary>
    /// Moves the objects and moves the hand if the way you're going changed recently
    /// </summary>
    private void FixedUpdate()
    {
        switch (_gameData.direction)
        {
            case Direction.UP:
                if (!setDepth)
                {
                    ScoreManager.Instance.depthCurrentRound = transform.position.y;
                    setDepth = true;
                }
                transform.Translate(Vector2.down * _speed / 4 * Time.fixedDeltaTime * 10);
                if (transform.position.y <= _startPosition.y)
                {
                    _gameData.direction = Direction.NONE;
                    _endScreen.SetActive(true);
                }
                if (moveHand)
                {
                    _hand.Translate(Vector2.down * _speed / 10 * Time.fixedDeltaTime);
                    if (_hand.position.y <= _desiredHandYPosition)
                    {
                        _hand.position = new Vector2(0, _desiredHandYPosition);
                        moveHand = false;
                    }
                }
            break;
            case (Direction.DOWN):
                percentage = transform.position.y / 1000;
                transform.Translate(Vector2.up * _speed / 20 * Time.fixedDeltaTime * (percentage + 1) * 10);
                if(transform.position.y >= 200 * (PlayerPrefs.GetInt("MaxDepth")))
                {
                    _gameData.direction = Direction.UP;
                }
            break;
            case (Direction.HEADSTART):
                _headStartTime += Time.fixedDeltaTime;
                int tHeadstartDepth = (PlayerPrefs.GetInt("StartDepth")-1) * 50;
                transform.position = Vector2.Lerp(_startPosition, Vector2.up * tHeadstartDepth, _headStartTime);
                if(_headStartTime >= 1)
                {
                    _gameData.direction = Direction.DOWN;
                }
            break;
        }
    }
}
