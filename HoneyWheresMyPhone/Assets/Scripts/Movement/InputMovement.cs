//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{

    /// <summary>
    /// Moves the gameObject to the position of the mouse/touch position
    /// </summary>
	void FixedUpdate()
    {
        if (GameData.Instance.direction != Direction.NONE)
        {
            float tNewPos = 0;
            if (Input.touchCount > 0)
            {
                tNewPos = Input.GetTouch(0).position.x;
            }
            if (Input.GetMouseButton(0))
            {
                tNewPos = Input.mousePosition.x;
            }
            if (tNewPos != 0)
            {
                Vector2 tDesiredPosition = Vector2.zero;
                tDesiredPosition.x = tNewPos;
                tDesiredPosition = Camera.main.ScreenToWorldPoint(tDesiredPosition);
                tDesiredPosition.y = transform.position.y;
                transform.position = tDesiredPosition;
            }
        }
    }
}
