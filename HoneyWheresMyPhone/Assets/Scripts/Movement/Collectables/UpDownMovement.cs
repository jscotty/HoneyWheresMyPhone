using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMovement : MonoBehaviour
{


    private float variableHeight;
    private bool goingUp;
    // Use this for initialization
    void Start()
    {
        if (Random.Range(0,2) == 0)
        {
            goingUp = true;
        }
        else
        {
            goingUp = false;
        }
    }

    // movement looks better with a fixed update 
    void FixedUpdate()
    {

        Vector3 tPosition = transform.position;
        if (goingUp)
        {
            variableHeight -= Time.deltaTime;
            tPosition.y -= Time.deltaTime / 2;
            transform.position = tPosition;
            if (variableHeight <= -0.2f)
            {
                goingUp = false;
            }
        }
        else
        {
            variableHeight += Time.deltaTime;
            tPosition.y += Time.deltaTime / 2;
            transform.position = tPosition;
            if (variableHeight >= 0.2)
            {
                goingUp = true;
            }
        }
    }
}
