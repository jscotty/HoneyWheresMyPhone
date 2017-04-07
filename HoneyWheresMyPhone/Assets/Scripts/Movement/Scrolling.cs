using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    private bool _goingDown = false;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _hand;
    private bool moveHand = false;
    [SerializeField] private float _desiredHandMovement;

    private float _desiredHandYPosition;

    private void Start() {
        _desiredHandYPosition = _hand.transform.position.y - _desiredHandMovement;
    }

    public void ReverseMovement() {
        _goingDown = true;
        moveHand = true;
    }

    private void FixedUpdate() {
        if (_goingDown) {
            transform.Translate(Vector2.down * _speed / 20);
        }
        else {
            transform.Translate(Vector2.up * _speed / 20);
        }
        if (moveHand) {
            _hand.Translate(Vector2.down * _speed / 50);
            if (_hand.position.y <= _desiredHandYPosition) {
                _hand.position = new Vector2(0, _desiredHandYPosition);
                moveHand = false;
            }
        }
    }
}
