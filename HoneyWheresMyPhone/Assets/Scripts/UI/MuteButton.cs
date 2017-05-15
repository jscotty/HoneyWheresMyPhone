using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour {

    [SerializeField]
    private Sprite _idleEabled;
    [SerializeField]
    private Sprite _clickedEabled;
    [SerializeField]
    private Sprite _idleDisabled;
    [SerializeField]
    private Sprite _clickedDisabled;
    private Button _myButton;
    private SoundController _soundController;
    private Image _myImage;
    private SpriteState sprStateMuted = new SpriteState();
    private SpriteState sprStateNotMuted = new SpriteState();
    [SerializeField]
    private AudioClip _soundClip;

    /// <summary>
    /// gets the needed references and checks if it should show the enabled sprites or the disabled sprites
    /// </summary>
    private void OnEnable()
    {
        _myImage = GetComponent<Image>();
        _myButton = GetComponent<Button>();
        if (_soundController == null)
        {
            _soundController = SoundController.Instance;
        }
        sprStateMuted.pressedSprite = _clickedDisabled;
        sprStateNotMuted.pressedSprite = _clickedEabled;
        UpdateVisual();
       
    }

    /// <summary>
    /// mutes or unmutes the sound
    /// </summary>
    public void ToggleSound() 
    {
        _soundController.MayIPlaySound = !_soundController.MayIPlaySound;
        UpdateVisual();
        CheckForBGMusc();
    }

    /// <summary>
    /// updates the shown visual according to if sound is allowed to play or not 
    /// </summary>
    private void UpdateVisual()
    {
        if (_soundController.MayIPlaySound == true)
        {
            _myButton.spriteState = sprStateNotMuted;
            _myImage.sprite = _idleEabled;
        }
        else
        {
            _myButton.spriteState = sprStateMuted;
            _myImage.sprite = _idleDisabled;
        }
    }

    /// <summary>
    /// mutes or unmutes the actual backgroundmusic according to the MayIPlayASound boolean
    /// </summary>
    private void CheckForBGMusc()
    {
        if (_soundController.MayIPlaySound)
        {
            if (!_soundController.IsPlaying("BGMusic"))
            {
                _soundController.PlaySound(_soundClip,0.7f,null,true, "BGMusic",true);
            }
        }
        else
        {
            _soundController.DestroyAudioSource("BGMusic");
        }
    }
}
