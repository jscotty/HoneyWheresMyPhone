using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour {

	public Transform endItem { private get; set; }
    public Transform startItem { private get; set; }
    [SerializeField] private Transform _endItem;
    [SerializeField] private Transform _startItem;

    private bool backToStart = false;

    private Vector2 _targetStartPos;
    
    [SerializeField] private Transform _uiObject;

    private Vector2 _startPos;
    [SerializeField] private Vector2 _uiObjectDesiredLocation;

    private void Start()
    {
        endItem = _endItem;
        startItem = _startItem;
        _targetStartPos = (Vector2)endItem.position;
        _startPos = -_uiObjectDesiredLocation;
    }

    private void Update()
    {
        float tPercentage;
        if(GameData.Instance.direction == Direction.DOWN)
        {
            tPercentage = endItem.position.y / _targetStartPos.y;
            Vector2 tPosition = Vector2.Lerp(_uiObjectDesiredLocation, _startPos, tPercentage);
            _uiObject.localPosition = tPosition;
        }
        else if(GameData.Instance.direction == Direction.UP)
        {
            if (!backToStart)
            {
                _targetStartPos = startItem.position;
                _startPos = -_startPos;
                backToStart = true;
            }
            tPercentage = startItem.position.y / _targetStartPos.y;
            Vector2 tPosition = Vector2.Lerp(-_uiObjectDesiredLocation, _startPos, tPercentage);
            _uiObject.localPosition = tPosition;
        }
    }
}
