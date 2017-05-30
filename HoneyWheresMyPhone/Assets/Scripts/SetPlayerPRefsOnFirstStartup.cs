using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPRefsOnFirstStartup : MonoBehaviour {

    /// <summary>
    /// sets the basic values in the playerprefs if it's the first startup
    /// </summary>
    private void Awake()
    {
        if (PlayerPrefs.GetInt("FirstStartup") == 0)
        {
            PlayerPrefs.SetInt("FirstStartup",1);
            PlayerPrefs.SetInt("MaxDepth", 1);
            PlayerPrefs.SetInt("StartDepth", 1);
            PlayerPrefs.SetInt("ItemValue", 1);
            PlayerPrefs.Save();
        }
    }
}
