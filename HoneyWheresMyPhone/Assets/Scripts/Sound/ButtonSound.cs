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

    public void OnPress()
    {
        SoundController.Instance.PlaySound(_onPress, 1, null, false, "", true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_playedSound)
        {
            SoundController.Instance.PlaySound(_onHover);
            _playedSound = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _playedSound = false;
    }
}
