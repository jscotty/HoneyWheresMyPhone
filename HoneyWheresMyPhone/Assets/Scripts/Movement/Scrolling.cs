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
    private bool _moveHand = false;
    [SerializeField]
    private float _desiredHandMovement;
    private Vector2 _startPosition;

    [SerializeField] private GameObject _endScreen;
    private bool _setDepth = false;

    private float _desiredHandYPosition;

    private GameData _gameData;

    private float _headStartTime;

    public float percentage { get; private set; }
    
    /// <summary>
    /// sets the needed references
    /// </summary>
    private void Awake()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
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
                percentage = transform.position.y / 1000;
                if (!_setDepth)
                {
                    ScoreManager.Instance.depthCurrentRound = transform.position.y;
                    _setDepth = true;
                }
                transform.Translate(Vector2.down * _speed / 4 * Time.fixedDeltaTime * 10);
                if (transform.position.y <= _startPosition.y)
                {
                    _gameData.direction = Direction.NONE;
                    _endScreen.SetActive(true);
                }
            break;
            case (Direction.DOWN):
                percentage = transform.position.y / 1000;
                transform.Translate(Vector2.up * _speed / 20 * Time.fixedDeltaTime * (percentage + 1) * 10);
                if(transform.position.y >= 200 * (PlayerPrefs.GetInt("MaxDepth")))
                {
                _moveHand = true;
                    _gameData.direction = Direction.NONE;
                }
            break;
            case (Direction.HEADSTART):
                percentage = transform.position.y / 1000;
                _headStartTime += Time.fixedDeltaTime;
                int tHeadstartDepth = (PlayerPrefs.GetInt("StartDepth")-1) * 50;
                transform.position = Vector2.Lerp(_startPosition, Vector2.up * tHeadstartDepth, _headStartTime);
            break;
            case (Direction.NONE):
            if (_moveHand)
            {
                _hand.Translate(Vector2.down * _speed / 4 * Time.fixedDeltaTime);
                if (_hand.position.y <= _desiredHandYPosition)
                {
                    _hand.position = new Vector2(0, _desiredHandYPosition);
                    _gameData.direction = Direction.UP;
                    _moveHand = false;
                }
            }
            break;
        }
    }
}
