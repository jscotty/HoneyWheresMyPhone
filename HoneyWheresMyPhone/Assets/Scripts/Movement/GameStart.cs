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

    private void Awake()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
        _gameData.direction = Direction.NONE;
    }

    void Update()
    {
        if (!_started)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                _started = true;
                StartCoroutine(StartDelay());
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
        else if (!_done)
        {
            transform.Translate(Vector2.up * 3 / 20 * Time.deltaTime * 50);
        }
	}

    IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(2);
        StartGame();
        yield return new WaitForSeconds(4);
        _sprRendToChange.sprite = _sprToChangeTo;
        yield return new WaitForSeconds(2);
        for (int i = 0; i < _toDisable.Length; i++)
        {
            _toDisable[i].SetActive(false);
        }
    }

    private void StartGame()
    {
        _gameData.direction = Direction.DOWN;
        for (int i = 0; i < _objectsToEnable.Length; i++)
        {
            _objectsToEnable[i].enabled = true;
        }
    }
}
