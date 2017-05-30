using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField]
    private AudioClip _soundClip;
    [SerializeField]
    private float _volume = 1;
    [SerializeField]
    private bool _repeat;
    [SerializeField]
    private string _stringForSound;
    [SerializeField]
    private bool _dontDestroyOnLoad;
    [SerializeField]
    private bool _checkIfPlaying;
    [SerializeField]
    private bool _replaceOther;
    [SerializeField]
    private string _replacable;

    /// <summary>
    /// starts the background music
    /// </summary>
    private void Start()
    {
        if(_replaceOther && SoundController.Instance.IsPlaying(_replacable))
        {
            SoundController.Instance.DestroyAudioSource(_replacable);
        }
        if (!_checkIfPlaying || !SoundController.Instance.IsPlaying(_stringForSound))
        {
            SoundController.Instance.PlaySound(_soundClip, _volume, null, _repeat, _stringForSound, _dontDestroyOnLoad);
        }
    }
}
