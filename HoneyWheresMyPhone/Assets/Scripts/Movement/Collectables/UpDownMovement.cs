﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{
    private float _variableHeight;
    private bool _goingUp;
    /// <summary>
    /// sets the start direction at random
    /// </summary>
    void Start()
    {
        if (Random.Range(0,2) == 0)
        {
            _goingUp = true;
        }
        else
        {
            _goingUp = false;
        }
    }

    /// <summary>
    /// moves the item up and down
    /// </summary>
    private void FixedUpdate()
    {

        Vector3 tPosition = transform.position;
        if (_goingUp)
        {
            _variableHeight -= Time.deltaTime;
            tPosition.y -= Time.deltaTime / 2;
            transform.position = tPosition;
            if (_variableHeight <= -0.2f)
            {
                _goingUp = false;
            }
        }
        else
        {
            _variableHeight += Time.deltaTime;
            tPosition.y += Time.deltaTime / 2;
            transform.position = tPosition;
            if (_variableHeight >= 0.2)
            {
                _goingUp = true;
            }
        }
    }
}
