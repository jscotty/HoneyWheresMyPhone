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
    private string _stringForDestroy;
    [SerializeField]
    private bool _dontDestroyOnLoad;

    void Start()
    {
        SoundController.Instance.PlaySound(_soundClip, _volume, null, _repeat, _stringForDestroy, _dontDestroyOnLoad);
    }
}
