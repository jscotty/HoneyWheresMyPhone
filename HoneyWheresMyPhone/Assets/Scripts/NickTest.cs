using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This a class to quickly debug/test things
/// </summary>
public class NickTest : MonoBehaviour
{
    private float speed = 1;
    private float currentSpeed = 1;

    [SerializeField]
    private GameObject _toEnable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Plus))
        {
            speed++;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            speed--;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerPrefs.SetFloat("MoneyTotal", PlayerPrefs.GetFloat("MoneyTotal") + 100);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_toEnable.activeInHierarchy)
            {
                _toEnable.SetActive(false);
            }
            else
            {
                _toEnable.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.SetInt("MaxDepth", 1);
            PlayerPrefs.SetInt("StartDepth", 1);
            PlayerPrefs.SetInt("ItemValue", 1);
        }
        if (speed < 0)
        {
            speed = 0;
        }
        if (currentSpeed != speed)
        {
            Time.timeScale = speed;
            currentSpeed = speed;
        }
    }
}
