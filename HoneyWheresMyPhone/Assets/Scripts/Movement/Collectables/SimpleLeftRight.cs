using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLeftRight : MonoBehaviour {

    [SerializeField]
    private float _speed;
    private int _right;

    /// <summary>
    /// sets that starting direction
    /// </summary>
    private void Start()
    {
        _right = Random.Range(0, 2);
        if(_right == 0)
        {
            _right = -1;
        }
    }


    /// <summary>
    /// moves the bject
    /// </summary>
    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * _right * _speed / 2 * Time.fixedDeltaTime);

    }

    /// <summary>
    /// changes the direction on collision with a trigger with the correct name
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "LeftWall")
        {
            _right = 1;
        }
        else if (collision.gameObject.tag == "RightWall")
        {
            _right = -1;
        }
    }
}
