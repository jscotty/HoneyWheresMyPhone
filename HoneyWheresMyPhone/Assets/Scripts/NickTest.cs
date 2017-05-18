using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickTest : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("MaxDepth", 1);
        PlayerPrefs.SetInt("StartDepth", 1);
        PlayerPrefs.SetInt("ItemValue", 1);
    }

    /*private float speed = 1;
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
        if (speed < 0)
        {
            speed = 0;
        }
        if (currentSpeed != speed)
        {
            Time.timeScale = speed;
            currentSpeed = speed;
        }
    }*/
}
