using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawer : MonoBehaviour
{
    [SerializeField]private float _topSpawnY;
    [SerializeField]private float _botSpawnY;
    private Camera _camera;
    public List<GameObject> itemList;
    [SerializeField]private Transform _itemParent;
    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateItem(Direction.DOWN);
        }
    }

    public void CreateItem(Direction iDirection)
    {
        switch (iDirection)
        {
            case Direction.UP:
                Instantiate(itemList[Random.Range(0, itemList.Count)], new Vector3(Random.Range(0, Screen.width), _topSpawnY), Quaternion.identity, _itemParent);
                break;
            case Direction.DOWN:
                Vector3 tSpawnPos = _camera.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), 0));
                tSpawnPos.y = _botSpawnY;
                tSpawnPos.z = 0;
                Instantiate(itemList[Random.Range(0, itemList.Count)],tSpawnPos ,Quaternion.identity,_itemParent);
                break;
        }
    }
}

public enum Direction
{
    UP,
    DOWN
}