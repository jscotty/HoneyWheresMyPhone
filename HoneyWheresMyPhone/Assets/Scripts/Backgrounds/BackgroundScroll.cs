using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [SerializeField]
    private float _scrollSpeed;
    private GameData _gameData;
    [SerializeField]
    private Scrolling _scrolling;

    /// <summary>
    /// sets the needed references
    /// </summary>
    private void Awake()
    {
        _gameData = GameObject.FindGameObjectWithTag("GameData").GetComponent<GameData>();
    }

    /// <summary>
    /// Moves the background offset
    /// </summary>
    private void FixedUpdate()
    {
        Vector2 tDesiredPos = transform.position;
        switch (_gameData.direction) {
            case Direction.UP:
                tDesiredPos.y -= Time.fixedDeltaTime * _scrollSpeed / 20 * 16;
            break;
            case Direction.DOWN:
                tDesiredPos.y += Time.fixedDeltaTime * _scrollSpeed / 2 * (_scrolling.percentage + 1);
            break;
            case Direction.HEADSTART:
            tDesiredPos.y += Time.fixedDeltaTime * _scrollSpeed / 2 * (_scrolling.percentage + 1) * (5 * PlayerPrefs.GetInt("StartDepth"));
            break;
        }
        transform.position = tDesiredPos;
    }
}
