//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [SerializeField]
    private float _scrollSpeed;
    private Vector2 _currentOffset;
    [SerializeField]
    private Renderer _renderer;
    private GameData _gameData;
    [SerializeField]
    private Scrolling _scrolling;

    /// <summary>
    /// sets the needed references
    /// </summary>
    private void Awake()
    {
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();

    }
    /// <summary>
    /// Sets the start Offset for the background texture
    /// </summary>
    private void Start()
    {
        _currentOffset = _renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    /// <summary>
    /// Moves the background offset
    /// </summary>
    private void FixedUpdate()
    {
        switch (_gameData.direction) {
            case Direction.UP:
                _currentOffset.y += Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed / 20 * 16 * Time.fixedDeltaTime * 10 * 1.57f, 1);
            break;
            case Direction.DOWN:
                _currentOffset.y -= Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed / 20 * Time.fixedDeltaTime * 10 * (_scrolling.percentage + 1) * 4.8f, 1);
            break;
            case Direction.HEADSTART:
                _currentOffset.y -= Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed * 0.252f * 5 * PlayerPrefs.GetInt("StartDepth"), 1);
            break;
        }
        Vector2 offset = new Vector2(_currentOffset.x, _currentOffset.y);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
