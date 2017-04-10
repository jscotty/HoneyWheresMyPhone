using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookCollision : MonoBehaviour
{

    [SerializeField] private string _itemTag;
    [SerializeField] private Vector2 _desiredItemPosition;
    private List<ItemScores> _itemScores = new List<ItemScores>();
    [SerializeField] private Scrolling _scrolling;
    [SerializeField] private BackgroundScroll _backgroundScroll;
    private bool _goingUp = false;

    /// <summary>
    /// Triggers when an object is touched, if it is an item it will grab it and start moving up if it isn't already
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(_itemTag))
        {
            if (!_goingUp)
            {
                _scrolling.ReverseMovement();
                _backgroundScroll.ReverseScrolling();
                _goingUp = true;
            }
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.transform.localPosition = _desiredItemPosition;
            _itemScores.Add(collision.gameObject.GetComponent<ItemScores>());
            //ScoreManager.T.score += collision.gameObject.GetComponent<ItemScores>().Score();
            ItemScores tItemScores = collision.gameObject.GetComponent<ItemScores>();
            if (tItemScores.EndObject())
            {
                //ScoreManager.T.endobject = true;
            }
        }
    }
}
