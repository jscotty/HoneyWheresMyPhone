//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{

    private bool _goingUp = false;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _hand;
    private bool moveHand = false;
    [SerializeField] private float _desiredHandMovement;
    private Vector2 _startPosition;

    private float _desiredHandYPosition;

    private void Start()
    {
        _desiredHandYPosition = _hand.transform.position.y - _desiredHandMovement;
        _startPosition = (Vector2)transform.position;
    }

    /// <summary>
    /// reverses the movement
    /// </summary>
    public void ReverseMovement()
    {
        _goingUp = true;
        moveHand = true;
    }

    /// <summary>
    /// Moves the objects and moves the hand if the way you're going changed recently
    /// </summary>
    private void FixedUpdate()
    {
        if (_goingUp)
        {
            transform.Translate(Vector2.down * _speed / 20);
            if(transform.position.y >= _startPosition.y)
            {
                Debug.Log("We're back at the top");
            }
        }
        else
        {
            transform.Translate(Vector2.up * _speed / 20);
        }
        if (moveHand)
        {
            _hand.Translate(Vector2.down * _speed / 50);
            if (_hand.position.y <= _desiredHandYPosition)
            {
                _hand.position = new Vector2(0, _desiredHandYPosition);
                moveHand = false;
            }
        }
    }
}
