using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawer : Singleton<ItemSpawer>
{
    [SerializeField]
    private float _topSpawnY;
    [SerializeField]
    private float _botSpawnY;
    public List<GameObject> itemList;
    [SerializeField]
    private Transform _itemParent;
    [SerializeField]
    private Transform _leftBound;
    [SerializeField]
    private Transform _rightBound;
    private ItemController _itemController;
    private GameData _gameData;

    private void Awake()
    {
        _gameData = GameData.Instance;
        _itemController = ItemController.Instance;
    }

#if UNITY_EDITOR //as long as the update is just for debugging leave this here
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomItemAtRandomPosition();
        }
    }
#endif

    /// <summary>
    /// This function creates one random item from the itemlist at a random position.
    /// Y position is set according to the game direction
    /// </summary>
    /// <param name="iDirection"></param>
    public void CreateRandomItemAtRandomPosition()
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        if (_gameData == null)
        {
            _gameData = GameData.Instance;
        }
        Vector3 tSpawnPos = Vector3.Lerp(_leftBound.transform.position,_rightBound.transform.position,Random.Range(0f,1f));
        int tRandomItemindex = Random.Range(0, itemList.Count);
        tSpawnPos.z = 0;
        switch (_gameData.direction)
        {
            case Direction.UP:
                tSpawnPos.y = _topSpawnY;
                break;
            case Direction.DOWN:
                tSpawnPos.y = _botSpawnY;
                break;
        }
        GameObject tItem = Instantiate(itemList[tRandomItemindex], tSpawnPos, Quaternion.identity, _itemParent);
        ItemBase tItemScript = tItem.GetComponent<ItemBase>();
        tItemScript.itemIndexForSpawning = tRandomItemindex;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    public void CreateItemAtFixedPosition(Vector3 iPosition, GameObject iItem)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(iItem, iPosition, Quaternion.identity, _itemParent);
        ItemBase tItemScript = tItem.GetComponent<ItemBase>();
        _itemController.AddItemToList(tItemScript);

    }


    public void CreateItemAtFixedLocalPosition(Vector3 iLocalPosition, GameObject iItem)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(iItem, new Vector3(0, _topSpawnY, 0), Quaternion.identity, _itemParent);
        tItem.transform.localPosition = iLocalPosition;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    public void CreateItemAtFixedLocalPosition(Vector3 iLocalPosition, int iItemSpawnIndex)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(itemList[iItemSpawnIndex], new Vector3(0, _topSpawnY, 0), Quaternion.identity, _itemParent);
        tItem.transform.localPosition = iLocalPosition;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }
}

