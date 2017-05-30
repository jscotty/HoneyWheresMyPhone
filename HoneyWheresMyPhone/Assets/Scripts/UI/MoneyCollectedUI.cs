using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCollectedUI : MonoBehaviour {

    public static MoneyCollectedUI Instance;

    private int _currentScore = 0;
    [SerializeField]
    private Text _text;

    /// <summary>
    /// sets the instance variable to this 
    /// </summary>
    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// Calls the update text function when this object gets enabled
    /// </summary>
    private void OnEnable()
    {
        UpdateText();
    }

    /// <summary>
    /// starts the addscore coroutine
    /// </summary>
    /// <param name="iScore"></param>
    public void AddScore(int iScore)
    {
        StartCoroutine(AddScoreDelay(iScore));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iScore"></param>
    /// <returns></returns>
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

    /// <summary>
    /// updates the text object
    /// </summary>
    private void UpdateText()
    {
        _text.text = "$" + _currentScore;
    }
}
