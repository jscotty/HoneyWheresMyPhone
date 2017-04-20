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
            _targetStartPos = value.position;
        }
    }
    private Transform _endItem;
    public Transform StartItem { private get; set; }
        /* this is for debugging
    //[SerializeField] private Transform _endItem;
    //[SerializeField] private Transform _startItem;
    */

    private bool backToStart = false;

    private Vector2 _targetStartPos;
    
    [SerializeField] private RectTransform _uiObject;

    [SerializeField] private Transform _startPosTransform;

    private Vector2 _startPos;
    [SerializeField] private Vector2 _uiObjectDesiredLocation;
    private float _recordedPercentage;

    private void Start()
    {
        /* this is for debugging
        //endItem = _endItem;
        //startItem = _startItem;
        */
        //_targetStartPos = (Vector2)EndItem.position;
        _startPos = -_uiObjectDesiredLocation;
        StartItem = _startPosTransform;
    }

    private void Update()
    {
        float tPercentage = 0;
        if(GameData.Instance.direction == Direction.DOWN)
        {
            tPercentage = EndItem.position.y / _targetStartPos.y;
            Vector2 tPosition = Vector2.Lerp(_uiObjectDesiredLocation, _startPos,  1- tPercentage);
            _uiObject.anchoredPosition = tPosition;
            _recordedPercentage = tPercentage;
        }
        else if(GameData.Instance.direction == Direction.UP)
        {
            if (!backToStart)
            {
                _targetStartPos = StartItem.position;
                _startPos = -_startPos;
                backToStart = true;
            }
            tPercentage = StartItem.position.y / _targetStartPos.y;

            Vector2 tPosition = Vector2.Lerp(-_uiObjectDesiredLocation, _startPos, 1-Mathf.Lerp(0,_recordedPercentage,tPercentage));
            _uiObject.anchoredPosition = tPosition;
        }
    }
}
