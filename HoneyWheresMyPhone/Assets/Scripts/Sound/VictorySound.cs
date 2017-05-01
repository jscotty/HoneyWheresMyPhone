using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour {

    [SerializeField] private AudioClip _victoryMusic1;
    [SerializeField] private AudioClip _victoryMusic2;
    [SerializeField] private AudioClip _backgroundMusic;

    void Start () {
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
        StartCoroutine(PlayMusic());
	}
    
    private IEnumerator PlayMusic()
    {
        SoundController.Instance.DestroyAudioSource("BGMusic");
        if (!ScoreManager.Instance.gainedEndObject)
        {
            SoundController.Instance.PlaySound(_victoryMusic1, 1, null, false, "", true);
            yield return new WaitForSeconds(_victoryMusic1.length);
        }
        else
        {
            SoundController.Instance.PlaySound(_victoryMusic2, 1, null, false, "", true);
            yield return new WaitForSeconds(_victoryMusic2.length);
        }
        SoundController.Instance.PlaySound(_backgroundMusic, 0.3f, null, true, "BGMusic", true);
        Destroy(this);
    }
}
