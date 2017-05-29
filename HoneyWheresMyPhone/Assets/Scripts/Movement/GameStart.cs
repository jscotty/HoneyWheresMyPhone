using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    private bool _started = false;
    private bool _done = false;
    [SerializeField]
    private MonoBehaviour[] _objectsToEnable;
    [SerializeField]
    private GameObject[] _toDisable;

    private GameData _gameData;
    
    [SerializeField]
    private SpriteRenderer _sprRendToChange;
    [SerializeField]
    private Sprite _sprToChangeTo;

    private Transform _hand;

    [SerializeField]
    private Vector2 _desiredHandPos;
    private Vector2 _handStartPos;
    private float _posTimer;

    /// <summary>
    /// Sets variables
    /// </summary>
    private void Awake()
    {
        _hand = HookCollision.handTransform.parent;
        _handStartPos = _hand.position;
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        _gameData.direction = Direction.NONE;
    }

    /// <summary>
    /// First checks if there is input from the player, and starts the game when it's received.
    /// Then moves the hand and the temporary backgrounds.
    /// After the hand is in the right position it only starts moving the background.
    /// </summary>
    private void Update()
    {
        if (!_started)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                _started = true;
                StartCoroutine(StartDelay());
                _hand.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = false;
                if(PlayerPrefs.GetInt("StartDepth") > 1)
                {
                    _gameData.direction = Direction.HEADSTART;
                }
                else
                {
                    _gameData.direction = Direction.DOWN;
                }
            }
        }
        else if (_done)
        {
            //Debug.Log("works " + Vector2.Lerp(_handStartPos, _desiredHandPos, _posTimer));
            _posTimer += Time.deltaTime / 2;
            Vector2 tLerpPos = Vector2.Lerp(_handStartPos, _desiredHandPos, _posTimer);
            tLerpPos.x = _hand.position.x;
            _hand.position = tLerpPos;

            transform.Translate(Vector2.up * 3 / 20 * Time.deltaTime * 50);
        }
        else
        {
            transform.Translate(Vector2.up * 3 / 20 * Time.deltaTime * 50);
        }
	}

    /// <summary>
    /// Creates all the start delays that are needed.
    /// After 2 seconds it starts the game.
    /// After another 0.5 seconds it starts the movement of the hand.
    /// After another 3.5 seconds it changes the foreground so if you immediately grab an item you cannot see the wrong foreground.
    /// After the next 0.5 seconds Enables the collider of the hand
    /// after the last 2.1 seconds it disables all the temporary items, including this script.
    /// </summary>
    /// <returns></returns>
    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2);
        StartGame();
        yield return new WaitForSeconds(0.5f);
        _done = true;
        yield return new WaitForSeconds(3.5f);
        _sprRendToChange.sprite = _sprToChangeTo;
        TutorialScreens.Instance.ShowScreen(0);
        yield return new WaitForSeconds(0.5f);
        _hand.GetChild(0).gameObject.GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(2.1f);
        for (int i = 0; i < _toDisable.Length; i++)
        {
            _toDisable[i].SetActive(false);
        }
    }

    /// <summary>
    /// Starts the game and enables the objects that need to be active in the game scene
    /// </summary>
    private void StartGame()
    {
        _gameData.direction = Direction.DOWN;
        for (int i = 0; i < _objectsToEnable.Length; i++)
        {
            _objectsToEnable[i].enabled = true;
        }
    }
}
