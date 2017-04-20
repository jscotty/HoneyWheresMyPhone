using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{

    [SerializeField] private string _itemTag;
    [SerializeField] private Vector2 _desiredItemPosition;
    //private List<ItemBase> _itemScores = new List<ItemBase>();
    [SerializeField] private Scrolling _scrolling;
    [SerializeField] private BackgroundScroll _backgroundScroll;
    private GameData _gameData;
    private ItemSpawer _itemSpawner;

    private void Awake()
    {
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        tGameobject = GameObject.FindGameObjectWithTag("ItemSpawner");
        _itemSpawner = tGameobject.GetComponent<ItemSpawer>();
#if UNITY_EDITOR
        Debug.Log("krijg de tering");
        Debug.Log("gamedata? " + _gameData);
#endif
    }

    /// <summary>
    /// Triggers when an object is touched, if it is an item it will grab it and start moving up if it isn't already
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_itemTag))
        {
            if (_gameData.direction != Direction.UP)
            {
                _gameData.direction = Direction.UP;
                _itemSpawner.StopSpawningItems();
            }
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.localPosition = _desiredItemPosition;
            //_itemScores.Add(collision.gameObject.GetComponent<ItemBase>());
            ItemBase tItemScores = collision.gameObject.GetComponent<ItemBase>();
            ScoreManager.Instance.scoreCurrentRound += tItemScores.Score();
            if (tItemScores.EndObject())
            {
                ScoreManager.Instance.gainedEndObject = true;
            }
        }
    }
}
