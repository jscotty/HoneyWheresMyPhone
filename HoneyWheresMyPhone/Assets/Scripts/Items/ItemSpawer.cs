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

#if UNITY_EDITOR //as long as the update is just for debugging leave this here
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateRandomItemAtRandomPosition(Direction.DOWN);
        }
    }
#endif

    /// <summary>
    /// This function creates one random item from the itemlist at a random position.
    /// </summary>
    /// <param name="iDirection"></param>
    public void CreateRandomItemAtRandomPosition(Direction iDirection)
    {
        Vector3 tSpawnPos = Vector3.Lerp(_leftBound.transform.position,_rightBound.transform.position,Random.Range(0f,1f));
        int tRandomItemindex = Random.Range(0, itemList.Count);
        tSpawnPos.z = 0;
        switch (iDirection)
        {
            case Direction.UP:
                tSpawnPos.y = _topSpawnY;
                break;
            case Direction.DOWN:
                tSpawnPos.y = _botSpawnY;
                break;
        }
        Instantiate(itemList[tRandomItemindex], tSpawnPos, Quaternion.identity, _itemParent);
    }

    public void CreateItemAtFixedPosition(Direction iDirection, Vector3 iPosition, GameObject iItem)
    {
        Instantiate(iItem, iPosition, Quaternion.identity, _itemParent);
    }


    public void CreateItemAtFixedLocalPosition(Direction iDirection, Vector3 iLocalPosition, GameObject iItem)
    {
        GameObject tItem = Instantiate(iItem, new Vector3(0,_topSpawnY,0), Quaternion.identity, _itemParent);
        tItem.transform.localPosition = iLocalPosition;
    }
}

