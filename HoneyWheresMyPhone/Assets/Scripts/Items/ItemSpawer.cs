using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawer : Singleton<ItemSpawer>
{
    [SerializeField]
    private float _topSpawnY;
    [SerializeField]
    private float _botSpawnY;
    public List<GameObject> itemsTierOne;
    public List<GameObject> itemsTierTwo;
    public List<GameObject> itemsTierThree;
    [SerializeField]
    private GameObject[] endItems;
    public Transform itemParent;
    [SerializeField]
    private Transform _leftBound;
    [SerializeField]
    private Transform _rightBound;
    private ItemController _itemController;
    [SerializeField]
    private float _itemSpawnDelay;
    private GameData _gameData;
    private ItemSpawer _itemSpawner;

    private int _currentDepthCount = 3;
    public int itemPerWave;

    /// <summary>
    /// Sets the needed refereces.
    /// </summary>
    private void Awake()
    {
        GameObject tGameobject = GameObject.FindGameObjectWithTag("GameData");
        _gameData = tGameobject.GetComponent<GameData>();
        //_itemController = ItemController.Instance;
        //tGameobject = GameObject.FindGameObjectWithTag("ProgressBar");
        //_progressBar = tGameobject.GetComponent<ProgressBar>();
        tGameobject = GameObject.FindGameObjectWithTag("ItemSpawner");
        _itemSpawner = tGameobject.GetComponent<ItemSpawer>();
        _itemController = tGameobject.GetComponent<ItemController>();
        if (itemPerWave == 0)
        {
            itemPerWave = 2;
        }
    }

    /// <summary>
    /// spawns the end item
    /// </summary>
    private void Start()
    {
        SpawnEndItems();
    }

    /// <summary>
    /// stops spawning items
    /// </summary>
    public void StopSpawningItems()
    {
        StopCoroutine("ItemSpawnDelay");
    }

    /// <summary>
    /// creates the items according to the depth of the itemparent
    /// </summary>
    private void Update()
    {
        if (Mathf.RoundToInt(itemParent.position.y / 5) >= _currentDepthCount)
        {
            _currentDepthCount++;
            for (int i = 0; i < itemPerWave; i++)
            {
                CreateRandomItemAtRandomPosition();
            }
        }
    }

    /// <summary>
    /// This function creates one random item from the itemlist at a random position.
    /// Y position is set according to the game direction
    /// </summary>
    /// <param name="iDirection"></param>
    public void CreateRandomItemAtRandomPosition()
    {
        Vector3 tSpawnPos = Vector3.Lerp(_leftBound.transform.position,_rightBound.transform.position,Random.Range(0f,1f));
        int tRandomItemindex = Random.Range(0, itemsTierOne.Count);
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
        GameObject tItem;
        if (itemParent.transform.position.y < 333f)
        {
            tItem = Instantiate(itemsTierOne[tRandomItemindex], tSpawnPos, Quaternion.identity, itemParent);
        }
        else if (itemParent.transform.position.y < 666f)
        {
            tItem = Instantiate(itemsTierTwo[tRandomItemindex], tSpawnPos, Quaternion.identity, itemParent);
        }
        else
        {
            tItem = Instantiate(itemsTierThree[tRandomItemindex], tSpawnPos, Quaternion.identity, itemParent);
        }
        ItemBase tItemScript = tItem.GetComponent<ItemBase>();
        tItemScript.itemIndexForSpawning = tRandomItemindex;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }


    /// <summary>
    /// creates an item at a fixed world position in the itemparent  
    /// </summary>
    /// <param name="iPosition">the spawnposition</param>
    /// <param name="iItem">the item to spawn</param>
    public void CreateItemAtFixedPosition(Vector3 iPosition, GameObject iItem)
    {
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
        GameObject tItem;
        if (itemParent.transform.position.y < 333f)
        {
            tItem = Instantiate(itemsTierOne[iItemSpawnIndex], new Vector3(0, _topSpawnY, 0), Quaternion.identity, itemParent);
        }
        else if (itemParent.transform.position.y < 666f)
        {
            tItem = Instantiate(itemsTierTwo[iItemSpawnIndex], new Vector3(0, _topSpawnY, 0), Quaternion.identity, itemParent);
        }
        else
        {
            tItem = Instantiate(itemsTierThree[iItemSpawnIndex], new Vector3(0, _topSpawnY, 0), Quaternion.identity, itemParent);
        }
        tItem.transform.localPosition = iLocalPosition;
        _itemController.AddItemToList(tItem.GetComponent<ItemBase>());
    }

    /* this will be used if we implement fixed waves
    public void SpawnRandomWave()
    {
        int tWaveIndex = Random.Range(0, _waves.Count);
        for (int i = 0; i < _waves[tWaveIndex].xPositions.Length; i++)
        {

        }
    }
    */

    /// <summary>
    /// spawns the end items that are in ned of spawning
    /// the end items that are already collected will not be respawned again except for the last one
    /// </summary>
    public void SpawnEndItems()
    {
        Vector3 tSpawnPos;
        int tPhonesCollected = PlayerPrefs.GetInt("PhonesCollected");
        for (int i = 0; i < endItems.Length; i++)
        {
            if (i<tPhonesCollected && i != endItems.Length-1)
            {
                continue;
            }
            tSpawnPos = new Vector3();
            tSpawnPos = Vector3.Lerp(_leftBound.transform.position, _rightBound.transform.position, Random.Range(0f, 1f));
            tSpawnPos.z = 0;
            GameObject tItem = Instantiate(endItems[i], tSpawnPos, Quaternion.identity);
            tItem.transform.SetParent(itemParent, true);
            Vector3 tSpawnLocalPos = tItem.transform.localPosition;
            tSpawnLocalPos.y = -198 - 200 * i;
            tItem.transform.localPosition = tSpawnLocalPos;
        }
    }

    /// <summary>
    /// used for spawning the items per set delay
    /// </summary>
    IEnumerator ItemSpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_itemSpawnDelay);
            for (int i = 0; i < itemPerWave; i++)
            {
                CreateRandomItemAtRandomPosition();
            } 
        }
    }

    /* this will be used if we implement fixed waves
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
    */
}

