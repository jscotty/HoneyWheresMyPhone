using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This a class to quickly debug/test things
/// </summary>
public class RockyTest : MonoBehaviour
{
    /// <summary>
    /// reset all the playerprefs to default values
    /// </summary>
    private void Awake()
    {
        PlayerPrefs.SetInt("MaxDepth",5);
        PlayerPrefs.SetInt("StartDepth",1);
        PlayerPrefs.SetInt("ItemValue",1);
        PlayerPrefs.SetFloat("MoneyTotal", 399);
    }
}
