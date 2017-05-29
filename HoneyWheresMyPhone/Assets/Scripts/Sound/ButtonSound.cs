using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private AudioClip _onHover;
    [SerializeField]
    private AudioClip _onPress;

    private bool _playedSound = false;

    /// <summary>
    /// plays the button ckick sound
    /// </summary>
    public void OnPress()
    {
        SoundController.Instance.PlaySound(_onPress, 1, null, false, "", true);
    }

    /// <summary>
    /// plays the button siund for when the cursor moves above the button
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_playedSound)
        {
            SoundController.Instance.PlaySound(_onHover);
            _playedSound = true;
        }
    }

    /// <summary>
    /// resets the boolean for the on pointer enter sound
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        _playedSound = false;
    }
}
