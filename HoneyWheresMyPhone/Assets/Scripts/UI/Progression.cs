using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Progression : MonoBehaviour {

    [SerializeField]
    private Text _progressionText;
    [SerializeField]
    private string _textBehindDepth;
    [SerializeField]
    private Transform _movingObject;

    /// <summary>
    /// updates the progression text
    /// </summary>
    private void FixedUpdate()
    {
        _progressionText.text = (int)_movingObject.position.y + _textBehindDepth;
    }
}

/* OBSOLETE
public class ProgressBar : MonoBehaviour {
    public Transform EndItem
    {
        private get
        {
            return _endItem;
        }
        set
        {
            _endItem = value;
            _endItemPos = _endItem.position;
        }
    }
    private Transform _endItem;
    private Vector2 _endItemPos;
    public Transform StartItem { private get; set; }

    [SerializeField] private RectTransform _uiObject;
    [SerializeField] private RectTransform _endUiObject;

    [SerializeField] private Transform _startPosTransform;

    private Vector2 _startPos;
    private Vector2 _uiObjectDesiredLocation;

    private void Start()
    {
        _startPos = _uiObject.anchoredPosition;
        StartItem = _startPosTransform;
        _uiObjectDesiredLocation = -_uiObject.anchoredPosition;
        StartCoroutine(checkForEnd());
    }

    private void Update()
    {
        float tPercentage = 0;
        tPercentage = StartItem.position.y / -_endItemPos.y;
        Vector2 tPosition = Vector2.Lerp(_startPos, _uiObjectDesiredLocation, tPercentage);
        //Debug.Log(tPercentage + " " + tPosition + " " + _startPos + " " + _uiObjectDesiredLocation);
        _uiObject.anchoredPosition = tPosition;
    }

    private IEnumerator checkForEnd()
    {
        while (true)
        {
            if (ScoreManager.Instance.gainedEndObject)
            {
                _endUiObject.SetParent(_uiObject);
                _endUiObject.SetSiblingIndex(0);
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(1);
            }
        }
    }
}*/
