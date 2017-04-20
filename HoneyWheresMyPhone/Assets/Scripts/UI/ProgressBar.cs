using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Singleton<ProgressBar> {

	public Transform EndItem
    {
        private get
        {
            return _endItem;
        }
        set
        {
            _endItem = value;
        }
    }
    private Transform _endItem;
    private Vector2 _endItemPos;
    public Transform StartItem { private get; set; }
    /* //this is for debugging
    //[SerializeField] private Transform _endItemSerializefield;
    */
    [SerializeField] private RectTransform _uiObject;

    [SerializeField] private Transform _startPosTransform;

    private Vector2 _startPos;
    private Vector2 _uiObjectDesiredLocation;

    private void Start()
    {
        /* //this is for debugging
        //_endItem = _endItemSerializefield;
        */
        _endItemPos = _endItem.position;
        _startPos = _uiObject.anchoredPosition;
        StartItem = _startPosTransform;
        _uiObjectDesiredLocation = -_uiObject.anchoredPosition;
    }

    private void Update()
    {
        float tPercentage = 0;
        tPercentage = StartItem.position.y / -_endItemPos.y;
        Vector2 tPosition = Vector2.Lerp(_startPos, _uiObjectDesiredLocation, tPercentage);
        //Debug.Log(tPercentage + " " + tPosition + " " + _startPos + " " + _uiObjectDesiredLocation);
        _uiObject.anchoredPosition = tPosition;
    }
}
