using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesController : MonoBehaviour {

    private int[] upgradeCosts = new int[] { 400, 800, 1600, 3200 };
    [SerializeField]
    private UpgradeTierController[] _tierControllers;
    private int[] _upgradeTiers = new int[3];
    private int money;
    [SerializeField]
    private Text _currentmoneyText;


    /// <summary>
    /// Gets the values it needs to function properly every time the upgrade screen is enabled
    /// </summary>
    private void OnEnable()
    {
        _upgradeTiers[0] = PlayerPrefs.GetInt("MaxDepth");
        _upgradeTiers[1] = PlayerPrefs.GetInt("StartDepth");
        _upgradeTiers[2] = PlayerPrefs.GetInt("ItemValue");

        //for first initialization of the game tiers cant be 0 
        for (int i = 0; i < _upgradeTiers.Length; i++)
        {
            if (_upgradeTiers[i] == 0)
            {
                Upgrade(i);
            }
            else
            {
                _tierControllers[i].SetTier(_upgradeTiers[i]);
            }
        }
        UpdateCurrentMoneyText();
    }

    /// <summary>
    /// this sets the depth upgrade tier to current tier +1
    /// </summary>
    private void UpgradeDepth()
    {
        PlayerPrefs.SetInt("MaxDepth", PlayerPrefs.GetInt("MaxDepth") +1);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// this sets the startdepth upgrade tier to current tier +1
    /// </summary>
    private void UpgradeStartDepth()
    {
        PlayerPrefs.SetInt("StartDepth", PlayerPrefs.GetInt("StartDepth") + 1);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// this sets the itemvalue upgrade tier to current tier +1
    /// </summary>
    private void UpgradeItemValue()
    {
        PlayerPrefs.SetInt("ItemValue", PlayerPrefs.GetInt("ItemValue") + 1);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Call the upgrade function and calls the right functions according to iWatIsUpgraded
    /// </summary>
    /// <param name="iWhatIsUpgraded">the index of the upgrade in the array</param>
    public void Upgrade(int iWhatIsUpgraded)
    {
        if (PlayerPrefs.GetFloat("MoneyTotal") >= upgradeCosts[_upgradeTiers[iWhatIsUpgraded]-1])
        {
            PlayerPrefs.SetFloat("MoneyTotal", PlayerPrefs.GetFloat("MoneyTotal") - upgradeCosts[_upgradeTiers[iWhatIsUpgraded]-1]);
            UpdateCurrentMoneyText();
            _upgradeTiers[iWhatIsUpgraded]++;
            _tierControllers[iWhatIsUpgraded].Upgrade();
            switch (iWhatIsUpgraded)
            {
                case 0:
                    UpgradeDepth();
                    break;
                case 1:
                    UpgradeStartDepth();
                    break;

                case 2:
                    UpgradeItemValue();
                    break;
            } 
        }
    }

    /// <summary>
    /// upgrades the current money text to the current money
    /// </summary>
    private void UpdateCurrentMoneyText()
    {
        _currentmoneyText.text = "$" + PlayerPrefs.GetFloat("MoneyTotal").ToString();
    }
}
