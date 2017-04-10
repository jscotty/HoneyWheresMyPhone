using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : Singleton<ItemController>
{
    public Transform topBound;
    public Transform bottomBound;
    List<GameObject> itemList = new List<GameObject>();
    List<Vector3> itemPositionList = new List<Vector3>();
    [SerializeField]
    private bool _UseDestroyLogic; //if this is true is the destroy/instantiae logic else use the disable/enable logic for the items

    private void Awake()
    {
        GetBounds();
    }

    void Update()
    {
        if (topBound == null || bottomBound == null)
        {
            GetBounds();
        }
        if (_UseDestroyLogic)
        {

        }
    }

    void GetBounds()
    {
        topBound = GameObject.FindGameObjectWithTag("TopBound").transform;
        bottomBound = GameObject.FindGameObjectWithTag("BottomBound").transform;
    }
}
