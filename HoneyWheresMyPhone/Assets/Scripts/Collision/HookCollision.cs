using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{

    [SerializeField] private string _itemTag;
    [SerializeField] private Scrolling _scrolling;
    [SerializeField] private BackgroundScroll _backgroundScroll;
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private AudioClip _collectEndSound;
    private GameData _gameData;
    private ItemSpawer _itemSpawner;
    public static Transform handTransform;

    /// <summary>
    /// Sets variables
    /// </summary>
    private void Awake()
    {
        handTransform = transform;
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        tGameobject = GameObject.FindGameObjectWithTag("ItemSpawner");
        _itemSpawner = tGameobject.GetComponent<ItemSpawer>();
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
                TutorialScreens.Instance.ShowScreen(1);
                GetComponent<Animator>().SetBool("GrabbedItem", true);
            }
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.transform.SetParent(null);
            collision.gameObject.AddComponent<MoveOutOfScreen>();
            ItemBase tItemScores = collision.gameObject.GetComponent<ItemBase>();
            ScoreManager.Instance.scoreCurrentRound += tItemScores.Score();
            if (tItemScores.EndObject())
            {
                SoundController.Instance.PlaySound(_collectEndSound);
                ScoreManager.Instance.gainedEndObject++;
            }
            else
            {
                SoundController.Instance.PlaySound(_collectSound);
            }
        }
    }
}
