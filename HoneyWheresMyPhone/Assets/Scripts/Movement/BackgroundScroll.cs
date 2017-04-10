//@author Nick van Dokkum

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{

    [SerializeField] private float _scrollSpeed;
    private Vector2 _currentOffset;
    [SerializeField] private Renderer _renderer;

    /// <summary>
    /// Sets the start Offset for the background texture
    /// </summary>
    private void Start()
    {
        _currentOffset = _renderer.sharedMaterial.GetTextureOffset("_MainTex");
    }

    /// <summary>
    /// Moves the background offset
    /// </summary>
    private void FixedUpdate()
    {
        if (GameData.Instance.direction == Direction.UP)
        {
            _currentOffset.y += Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed * 0.495f, 1); //The 0.495f is to make it scroll at the same speed as the items
        }
        else
        {
            _currentOffset.y -= Mathf.Repeat(Time.fixedDeltaTime * _scrollSpeed * 0.495f, 1);
        }
        Vector2 offset = new Vector2(_currentOffset.x, _currentOffset.y);
        _renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
