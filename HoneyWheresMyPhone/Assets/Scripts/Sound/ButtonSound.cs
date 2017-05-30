using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _onPress;

    public void OnPress()
    {
        SoundController.Instance.PlaySound(_onPress, 1, null, false, "", true);
    }
}
