﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{

    [SerializeField] private string _itemTag;
    [SerializeField] private Vector2 _desiredItemPosition;
    //private List<ItemBase> _itemScores = new List<ItemBase>();
    [SerializeField] private Scrolling _scrolling;
    [SerializeField] private BackgroundScroll _backgroundScroll;
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private AudioClip _collectEndSound;
    private GameData _gameData;
    private ItemSpawer _itemSpawner;
    public static Transform handTransform;

    private Collider2D _collider;

    /// <summary>
    /// Sets variables
    /// </summary>
    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        handTransform = transform;
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        tGameobject = GameObject.FindGameObjectWithTag("ItemSpawner");
        _itemSpawner = tGameobject.GetComponent<ItemSpawer>();
#if UNITY_EDITOR
        //Debug.Log("gamedata? " + _gameData);
#endif
    }

    private void Start()
    {
        _collider.enabled = false;
        StartCoroutine(invincDelay());
    }

    IEnumerator invincDelay()
    {
        while(_gameData.direction == Direction.NONE)
        {
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(5);
        _collider.enabled = true;
        yield break;
    }

    /// <summary>
    /// Triggers when an object is touched, if it is an item it will grab it and start moving up if it isn't already
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_gameData.direction != Direction.HEADSTART && collision.gameObject.CompareTag(_itemTag))
        {
            if (_gameData.direction == Direction.DOWN)
            {
                _gameData.direction = Direction.UP;
                _itemSpawner.StopSpawningItems();
            }
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.AddComponent<MoveOutOfScreen>();
            //_itemScores.Add(collision.gameObject.GetComponent<ItemBase>());
            ItemBase tItemScores = collision.gameObject.GetComponent<ItemBase>();
            ScoreManager.Instance.scoreCurrentRound += tItemScores.Score();
            if (tItemScores.EndObject())
            {
                SoundController.Instance.PlaySound(_collectEndSound);
                ScoreManager.Instance.gainedEndObject = true;
            }
            else
            {
                SoundController.Instance.PlaySound(_collectSound);
            }
        }
    }
}
