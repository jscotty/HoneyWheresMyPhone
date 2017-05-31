using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundController : Singleton<SoundController>
{

    private List<string> _currentSounds = new List<string>();
    private List<AudioSource> _currentAudioSources = new List<AudioSource>();
    private GameObject _soundObject;
    private bool _mayIPlaySound;
    /// <summary>
    /// public get and set on set also toggle the audio listener on or off
    /// </summary>
    public bool MayIPlaySound
    {
        get
        {
            return _mayIPlaySound;
        }
        set
        {
            _mayIPlaySound = value;
            PlayerPrefs.SetInt("SoundEnabled", Convert.ToInt32(value));
            PlayerPrefs.Save();
            
        }
    }


    void Awake()
    {
        if (PlayerPrefs.GetInt("SoundEnabled") == 0)
        {
            MayIPlaySound = false;

        }
        else
        {
            MayIPlaySound = true;
        }
        _soundObject = new GameObject("soundObj");
        _soundObject.transform.SetParent(transform);
        _soundObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// plays a sound when called
    /// </summary>
    /// <param name="iSound">The sound file</param>
    /// <param name="iRepeating">Does the sound have to repeat</param>
    /// <param name="iParentForSound">Parental gameobject where the sound has to come from</param>
    /// <param name="iStringForDestroy">String to call the sound on if it needs to be destroyed</param>
    public void PlaySound(AudioClip iSound, float iVolume = 1, Transform iParentForSound = null, bool iRepeating = false, string iStringForDestroy = "", bool iDontDestroyOnLoad = false)
    {
        if (MayIPlaySound)
        {
            AudioSource tAudioSource = Instantiate(_soundObject).GetComponent<AudioSource>();
            if (iParentForSound != null)
            {
                tAudioSource.transform.SetParent(iParentForSound);
            }
            tAudioSource.loop = iRepeating;
            tAudioSource.clip = iSound;
            tAudioSource.volume = iVolume;
            tAudioSource.Play();
            if (!iRepeating)
            {
                StartCoroutine(DestroyAFterDone(tAudioSource));
            }
            else
            {
                _currentSounds.Add(iStringForDestroy);
                _currentAudioSources.Add(tAudioSource);
            }
            if (iDontDestroyOnLoad)
            {
                DontDestroyOnLoad(tAudioSource.gameObject);
            }
        }
    }

    /// <summary>
    /// Checks if a sound is done playing and destroys it if it is
    /// </summary>
    /// <param name="iAudioSource">The AudioSource to test</param>
    IEnumerator DestroyAFterDone(AudioSource iAudioSource)
    {
        while (iAudioSource != null)
        {
            if (iAudioSource.isPlaying)
            {
                yield return new WaitForSeconds(1);
            }
            else
            {
                Destroy(iAudioSource.gameObject);
                yield break;
            }
        }
    }

    /// <summary>
    /// Destroys the given audio source
    /// </summary>
    /// <param name="iSoundToDestroy">The AudioSource that you want to be destroyed</param>
    public void DestroyAudioSource(string iSoundToDestroy)
    {
        if (!_mayIPlaySound)
        {
            bool tSoundDestroyed = false;
            for (int i = 0; i < _currentSounds.Count; i++)
            {
                if (_currentSounds[i] == iSoundToDestroy)
                {
                    tSoundDestroyed = true;
                    AudioSource tAudioSource = _currentAudioSources[i];
                    _currentAudioSources[i].Stop();
                    _currentSounds.RemoveAt(i);
                    _currentAudioSources.RemoveAt(i);
                    Destroy(tAudioSource.gameObject);
                }
            }
            if (!tSoundDestroyed)
            {
                Debug.LogError("The sound '" + iSoundToDestroy + "' is not found");
            }
        }
    }

    /// <summary>
    /// Returns if a sound with the current string is playing
    /// </summary>
    /// <param name="iSoundToCheck">The string to check if it's currently being used</param>
    /// <returns></returns>
    public bool IsPlaying(string iSoundToCheck)
    {
        if (_currentSounds.Contains(iSoundToCheck))
        {
            return true;
        }
        return false;
    }
}
