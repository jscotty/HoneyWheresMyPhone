using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTierController : MonoBehaviour {

    private int[] upgradeCosts = new int[] { 400, 800, 1600, 3200 };
    [SerializeField]
    private Image[] _images;

    [SerializeField]
    private Sprite _upgradeTrue;
    [SerializeField]
    private Sprite _upgradeMaybe;
    [SerializeField]
    private Sprite _upgradeFalse;
    [SerializeField]
    private Text priceVisual;

    private int _currentTier;

    public void SetTier(int iTier)
    {
#if UNITY_EDITOR
        Debug.Log("set to " + iTier);
#endif
        if (iTier > 5)
        {
            iTier = 5;
        }
        _currentTier = iTier;
        SetImages();
        SetText();
    }

    public void Upgrade()
    {
        _currentTier++;
        if (_currentTier > 5)
        {
            _currentTier = 5;
        }
        SetImages();
        SetText();
    }
#if UNITY_EDITOR
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Upgrade();
        }
    }
#endif

    public void SetImages()
    {
        for (int i = 0; i < _images.Length; i++)
        {
            if (i < _currentTier)
            {
                _images[i].sprite = _upgradeTrue;
                if (i + 1 < _images.Length)
                {
                    _images[i + 1].sprite = _upgradeMaybe;
                }
            }
        }
    }

    private void SetText()
    {
        
        if (_currentTier >= 5)
        {
            priceVisual.text = "------";
        }
        else
        {
            priceVisual.text = "$" + upgradeCosts[_currentTier - 1];
        }
    }
}
