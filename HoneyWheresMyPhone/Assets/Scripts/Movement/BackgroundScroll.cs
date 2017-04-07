using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
    
    [SerializeField] private float _scrollSpeed;
    private Vector2 savedOffset;
    [SerializeField] private Renderer _renderer;
    private bool _scrollUp = false;

    void Start() {
        savedOffset = _renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    void Update() {
        float y;
        if (_scrollUp) {
            y = Mathf.Repeat(Time.time * _scrollSpeed * 0.59f, 1);
        }
        else {
            y = Mathf.Repeat(-Time.time * _scrollSpeed * 0.59f, 1);
        }
        Vector2 offset = new Vector2(savedOffset.x, y);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
