using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Singleton<ItemController>
{
    public Transform topBound;
    public Transform bottomBound;
    public List<ItemBase> itemList = new List<ItemBase>();
    private List<ItemSpawnData> itemPositionList = new List<ItemSpawnData>();
    [SerializeField]
    private bool _UseDestroyLogic; //if this is true is the destroy/instantiae logic else use the disable/enable logic for the items
    private GameData _gameData;
    private ItemSpawer _itemSpawer;


    private void Awake()
    {
        GetBounds();
        _gameData = GameData.Instance;
        _itemSpawer = ItemSpawer.Instance;
    }

    void Update()
    {
        if (topBound == null || bottomBound == null)
        {
            GetBounds();
        }
        if (_UseDestroyLogic)
        {
            if (_gameData.direction == Direction.UP)
            {
                for (int i = itemPositionList.Count - 1; i >= 0; i--)
                {
                   // _itemSpawer.CreateItemAtFixedLocalPosition
                }
            }
        }
    }

    void GetBounds()
    {
        topBound = GameObject.FindGameObjectWithTag("TopBound").transform;
        bottomBound = GameObject.FindGameObjectWithTag("BottomBound").transform;
    }

    public void AddItemToList(ItemBase iItemScript)
    {
        itemList.Add(iItemScript);
    }

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
