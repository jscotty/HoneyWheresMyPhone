using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictorySound : MonoBehaviour
{
    [SerializeField]
    private AudioClip _victoryMusic;
    [SerializeField]
    private AudioClip _backgroundMusic;

    void Start()
    {
        transform.SetParent(null);
        DontDestroyOnLoad(gameObject);
        StartCoroutine(PlayMusic());
    }

    private IEnumerator PlayMusic()
    {
        SoundController.Instance.PlaySound(_victoryMusic, 1, null, false, "", true);
        yield return new WaitForSeconds(_victoryMusic.length);
        if (!SoundController.Instance.IsPlaying("BGMusic"))
        {
            SoundController.Instance.PlaySound(_backgroundMusic, 0.7f, null, true, "BGMusic", true);
        }
        Destroy(gameObject);
    }
}
