using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesController : MonoBehaviour {

    private int[] upgradeCosts = new int[] { 400, 800, 1600, 3200 };
    [SerializeField]
    private UpgradeTierController[] _tierControllers;
    private int[] _upgradeTiers = new int[3];
    private int money;
    private void Awake()
    {
        _upgradeTiers[0] = PlayerPrefs.GetInt("MaxDepth");
        _upgradeTiers[1] = PlayerPrefs.GetInt("StartDepth");
        _upgradeTiers[2] = PlayerPrefs.GetInt("ItemValue");

        //for first initialization of the game tiers cant be 0 
        for (int i = 0; i < _upgradeTiers.Length; i++)
        {
#if UNITY_EDITOR
            Debug.Log(string.Format("i : {0} - result {1}",i,_upgradeTiers[i]));
#endif
            if (_upgradeTiers[i] == 0)
            {
                Upgrade(i);
            }
            else
            {
                _tierControllers[i].SetTier(_upgradeTiers[i]);
            }
        }
    }



    private void UpgradeDepth()
    {
        PlayerPrefs.SetInt("MaxDepth", PlayerPrefs.GetInt("MaxDepth") +1);
        PlayerPrefs.Save();
    }

    private void UpgradeStartDepth()
    {
        PlayerPrefs.SetInt("StartDepth", PlayerPrefs.GetInt("StartDepth") + 1);
        PlayerPrefs.Save();
    }

    private void UpgradeItemValue()
    {
        PlayerPrefs.SetInt("ItemValue", PlayerPrefs.GetInt("ItemValue") + 1);
        PlayerPrefs.Save();
    }

    public void Upgrade(int iWhatIsUpgraded)
    {
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
