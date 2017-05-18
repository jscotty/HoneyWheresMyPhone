using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyTest : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefs.SetInt("MaxDepth",5);
        PlayerPrefs.SetInt("StartDepth",1);
        PlayerPrefs.SetInt("ItemValue",1);
        PlayerPrefs.SetFloat("MoneyTotal", 399);
    }
}
