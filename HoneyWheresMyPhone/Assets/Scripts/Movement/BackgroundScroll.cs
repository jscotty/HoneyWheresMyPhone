using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    
    [SerializeField] private float _scrollSpeed;
    private Vector2 _currentOffset;
    [SerializeField] private Renderer _renderer;
    private bool _scrollUp = false;

    private void Start() {
        _currentOffset = _renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    /// <summary>
    /// reverses the scrolling
    /// </summary>
    public void ReverseScrolling() {
        _scrollUp = true;
    }

    /// <summary>
    /// Moves the background offset
    /// </summary>
    private void FixedUpdate() {
        if (_scrollUp) {
            _currentOffset.y += Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed * 0.495f, 1);
        }
        else {
            _currentOffset.y -= Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed * 0.495f, 1);
        }
        Vector2 offset = new Vector2(_currentOffset.x, _currentOffset.y);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
