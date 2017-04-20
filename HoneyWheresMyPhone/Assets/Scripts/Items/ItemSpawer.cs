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
    private GameObject endItem; // nce we get more end items this has to be turned into a list
    public Transform itemParent;
    [SerializeField]
    private Transform _leftBound;
    [SerializeField]
    private Transform _rightBound;
    private ItemController _itemController;
    private GameData _gameData;
    [SerializeField]
    private List<WaveData> _waves;
    [SerializeField]
    private float _itemSpawnDelay;

    private void Awake()
    {
        _gameData = GameData.Instance;
        _itemController = ItemController.Instance;
    }

    private void Start()
    {
        SpawnEndItem();
        StartCoroutine("ItemSpawnDelay");
    }

    public void StopSpawningItems()
    {
        StopCoroutine("ItemSpawnDelay");
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
        GameObject tItem = Instantiate(itemList[tRandomItemindex], tSpawnPos, Quaternion.identity, itemParent);
        ItemBase tItemScript = tItem.GetComponent<ItemBase>();
        tItemScript.itemIndexForSpawning = tRandomItemindex;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    //TODO create chunk spawener

    /// <summary>
    /// creates an item at a fixed world position in the itemparent  
    /// </summary>
    /// <param name="iPosition">the spawnposition</param>
    /// <param name="iItem">the item to spawn</param>
    public void CreateItemAtFixedPosition(Vector3 iPosition, GameObject iItem)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(iItem, iPosition, Quaternion.identity, itemParent);
        ItemBase tItemScript = tItem.GetComponent<ItemBase>();
        _itemController.AddItemToList(tItemScript);

    }

    /// <summary>
    /// creates an item at a fixed local position in the itemparent
    /// </summary>
    /// <param name="iLocalPosition">the local position</param>
    /// <param name="iItem">the item that will be spawned</param>
    public void CreateItemAtFixedLocalPosition(Vector3 iLocalPosition, GameObject iItem)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(iItem, new Vector3(0, _topSpawnY, 0), Quaternion.identity, itemParent);
        tItem.transform.localPosition = iLocalPosition;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    /// <summary>
    /// creates an item at a fixed local position in the itemparent
    /// </summary>
    /// <param name="iLocalPosition">that local position</param>
    /// <param name="iItemSpawnIndex">the index of the item to spawn from the itemlist</param>
    public void CreateItemAtFixedLocalPosition(Vector3 iLocalPosition, int iItemSpawnIndex)
    {
        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        GameObject tItem = Instantiate(itemList[iItemSpawnIndex], new Vector3(0, _topSpawnY, 0), Quaternion.identity, itemParent);
        tItem.transform.localPosition = iLocalPosition;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    public void SpawnRandomWave()
    {
        //TO/do finish wave spawning
        int tWaveIndex = Random.Range(0, _waves.Count);
        for (int i = 0; i < _waves[tWaveIndex].xPositions.Length; i++)
        {

        }
    }

    public void SpawnEndItem()
    {
        float tDepth = _gameData.endItemDepth;

        if (_itemController == null)
        {
            _itemController = ItemController.Instance;
        }
        if (_gameData == null)
        {
            _gameData = GameData.Instance;
        }
        Vector3 tSpawnPos = Vector3.Lerp(_leftBound.transform.position, _rightBound.transform.position, Random.Range(0f, 1f));
        int tRandomItemindex = Random.Range(0, itemList.Count);
        tSpawnPos.z = 0;
        tSpawnPos.y = -_gameData.endItemDepth;
        GameObject tItem = Instantiate(endItem, tSpawnPos, Quaternion.identity);
        tItem.transform.SetParent(itemParent,true);
        Vector3 tSpawnLocalPos =    tItem.transform.localPosition;
        tSpawnLocalPos.y = -_gameData.endItemDepth;
        tItem.transform.localPosition = tSpawnLocalPos;
    }

    IEnumerator ItemSpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_itemSpawnDelay);
            for (int i = 0; i < 3; i++)
            {
                CreateRandomItemAtRandomPosition();
            } 
        }
    }

    [System.Serializable]
    struct WaveData
    {
        public float[] xPositions;
        public int difficulty; //if we want to sort them accordng to difficulties this will be an useful var

        public WaveData(int iDifficulty, params float[] iXposition)
        {
            xPositions = iXposition;
            difficulty = iDifficulty;
        }
    }
}

