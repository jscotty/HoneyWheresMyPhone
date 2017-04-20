using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Singleton<ItemController>
{
    public Transform topBound;
    public Transform bottomBound;
    public List<ItemBase> itemList = new List<ItemBase>();
    [SerializeField]//TODO remove this after debugging
    private List<ItemSpawnData> _itemPositionList = new List<ItemSpawnData>();
    [SerializeField]
    private bool _useDestroyLogic; //if this is true is the destroy/instantiae logic else use the disable/enable logic for the items
    private GameData _gameData;
    private ItemSpawer _itemSpawer;
    /// <summary>
    /// create references to the needed scripts and collects data where n eeded on startup  
    /// </summary>
    private void Awake()
    {
        GetBounds();
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        _itemSpawer = ItemSpawer.Instance;
    }

    /// <summary>
    /// the update checks if the items are within bounds and removes them or respawns them according to their registered positions
    /// </summary>
    void Update()
    {
        if (topBound == null || bottomBound == null)
        {
            GetBounds();
        }
        if (_useDestroyLogic)
        {
            if (_gameData.direction == Direction.UP)
            {
                for (int i = _itemPositionList.Count - 1; i >= 0; i--)
                {
                    //if the deleteheight is equal or greated the item has to be respawned
                    if (_itemPositionList[i].deleteHeight >= _itemSpawer.itemParent.position.y)
                    {
                        _itemSpawer.CreateItemAtFixedLocalPosition(_itemPositionList[i].itemLocalPosition,_itemPositionList[i].itemListIndex);
                        _itemPositionList.RemoveAt(i);
                    }
                }
            }
            else if(_gameData.direction == Direction.DOWN)
            {
                for (int i = itemList.Count - 1; i >= 0; i--)
                {   
                    //if the item is above the upperbound the item has to be removed
                    if (itemList[i].transform.position.y >= topBound.position.y)
                    {
                        _itemPositionList.Add(new ItemSpawnData(_itemSpawer.itemParent.position.y, itemList[i].transform.localPosition, itemList[i].itemIndexForSpawning));
                        Destroy(itemList[i].gameObject);
                        itemList.RemoveAt(i);
                    }
                }
            }
        }
        else
        {
            if (_gameData.direction == Direction.UP)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    //if the item is lower as the upperbound the item must be re enabled
                    if (itemList[i].transform.position.y <= topBound.position.y)
                    {
                        itemList[i].gameObject.SetActive(true);
                    }
                }
            }
            else if (_gameData.direction == Direction.DOWN)
            {
                for (int i = 0; i < itemList.Count; i++)
                {
                    //if the item is higher as the upperbound it has to be disabled
                    if (itemList[i].transform.position.y >= topBound.position.y)
                    {
                        itemList[i].gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    /// <summary>
    /// this function gets the upper and bottom ound from the scene
    /// </summary>
    void GetBounds()
    {
        topBound = GameObject.FindGameObjectWithTag("TopBound").transform;
        bottomBound = GameObject.FindGameObjectWithTag("BottomBound").transform;
    }

    /// <summary>
    /// this function adds the item to the itemlist
    /// </summary>
    /// <param name="iItemScript">the item to add</param>
    public void AddItemToList(ItemBase iItemScript)
    {
        itemList.Add(iItemScript);
    }

    /// <summary>
    /// the data needed to respawn the items if the destroy logic is enabled
    /// </summary>
    [System.Serializable]
    struct ItemSpawnData
    {
        public float deleteHeight;
        public Vector3 itemLocalPosition;
        public int itemListIndex;
        public ItemSpawnData(float iDeleteHeight, Vector3 iItemLocalPos, int iItemistIndex)
        {
            deleteHeight = iDeleteHeight;
            itemLocalPosition = iItemLocalPos;
            itemListIndex = iItemistIndex;
        }
    }
}
