using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollectedUI : MonoBehaviour {

    public static MoneyCollectedUI instance;

    private int _currentScore = 0;
    [SerializeField]
    private Text _text;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        UpdateText();
    }

    public void AddScore(int iScore)
    {
        StartCoroutine(AddScoreDelay(iScore));
    }

    private IEnumerator AddScoreDelay(int iScore)
    {
        int tScore = PlayerPrefs.GetInt("ItemValue");
        _currentScore += PlayerPrefs.GetInt("ItemValue");
        UpdateText();
        while (tScore < iScore)
        {
            yield return new WaitForSeconds(0.05f);
            _currentScore += PlayerPrefs.GetInt("ItemValue");
            tScore += PlayerPrefs.GetInt("ItemValue");
            UpdateText();
        }
    }
    private void UpdateText()
    {
        _text.text = "$" + _currentScore;
    }
}
