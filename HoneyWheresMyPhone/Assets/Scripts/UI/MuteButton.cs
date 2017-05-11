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
    private void OnEnable()
    {
        if (_soundController == null)
        {
            _soundController = SoundController.Instance;
        }
        if (_soundController.mayIPlaySound == true)
        {
            //_myButton.spriteState.pressedSprite = _clickedEabled;
        }
    }
}
