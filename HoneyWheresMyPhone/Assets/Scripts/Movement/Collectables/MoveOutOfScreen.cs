using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutOfScreen : MonoBehaviour {
    
    private float _strength = 0.5f;
    private float _speed = 1;
    private Vector3 DesiredPosition = new Vector2(-4, 6.5f);

    private void Start()
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        for(int i = 0; i < scripts.Length; i++)
        {
            scripts[i].enabled = false;
        }
        this.enabled = true;
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, DesiredPosition) > _speed) {
            transform.Translate((DesiredPosition - transform.position).normalized / 10 * _speed);
            transform.Translate(Vector2.down * _strength);
            _strength *= 0.9f;
            _speed *= 1.01f;
        }
        else {
            Debug.Log("done");
            transform.position = DesiredPosition;
            transform.SetParent(HookCollision.handTransform);
        }
    }
}
