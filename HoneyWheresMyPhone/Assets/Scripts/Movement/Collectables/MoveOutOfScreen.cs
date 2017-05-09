using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutOfScreen : MonoBehaviour {
    
    private float _strength = 0.5f;
    private float _speed = 1;
    private Vector3 DesiredPosition = new Vector2(-3.5f, 9.5f);
    private float _size = 1;

    /// <summary>
    /// Disables other movement scripts
    /// </summary>
    private void Start()
    {
        MonoBehaviour[] scripts = gameObject.GetComponents<MonoBehaviour>();
        for(int i = 0; i < scripts.Length; i++)
        {
            scripts[i].enabled = false;
        }
        this.enabled = true;
    }

    /// <summary>
    /// Moves the object, shrinks it and checks if it has reached it's destination
    /// </summary>
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, DesiredPosition) > _speed) {
            transform.Translate((DesiredPosition - transform.position).normalized / 10 * _speed);
            transform.Translate(Vector2.down * _strength);
            transform.localScale = Vector3.one * _size;
            _strength *= 0.9f;
            _speed *= 1.03f;
            _size -= 0.015f;
        }
        else {
            Debug.Log("done");
            transform.position = DesiredPosition;
            transform.SetParent(HookCollision.handTransform);
            GetComponent<Renderer>().enabled = false;
            this.enabled = false;
        }
    }
}
