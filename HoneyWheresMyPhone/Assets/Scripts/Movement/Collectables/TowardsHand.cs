using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsHand : MonoBehaviour {

    private Transform _hand;
    [SerializeField]
    private float _speed;

    private void Start()
    {
        _hand = HookCollision.handTransform;
    }

    private void FixedUpdate()
    {
        if(Vector2.Distance(new Vector2(_hand.position.x, 0), new Vector2(transform.position.x, 0)) > _speed / 50)
        {
            if (_hand.position.x > transform.position.x)
            {
                transform.Translate(Vector2.right * _speed / 50);
            }
            else
            {
                transform.Translate(Vector2.left * _speed / 50);
            }
        }
        else
        {
            transform.position = new Vector2(_hand.position.x, transform.position.y);
        }
    }
}
