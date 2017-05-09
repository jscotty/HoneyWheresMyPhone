using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeTierController : MonoBehaviour {

    private int[] upgradeCosts = new int[] { 400, 800, 1600, 3200 }; //prices of the upgrades
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

    /// <summary>
    /// set the upgrade to a tier used on startup to set all the visuals to the visuals they need to be
    /// </summary>
    /// <param name="iTier">the tier the upgrade is set to</param>
    public void SetTier(int iTier)
    {
        if (iTier > 5)
        {
            iTier = 5;
        }
        _currentTier = iTier;
        SetImages();
        SetText();
    }

    /// <summary>
    /// updates all the visuals for this upgrade
    /// </summary>
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

    /// <summary>
    /// sets the little dot images to the correct images
    /// </summary>
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

    /// <summary>
    /// Sets the price text for the upgrades
    /// </summary>
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
