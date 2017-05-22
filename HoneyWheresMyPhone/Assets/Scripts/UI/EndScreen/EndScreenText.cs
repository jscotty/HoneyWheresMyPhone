using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenText : MonoBehaviour {

    [SerializeField] private Text _highscoreDepth;
    [SerializeField] private Text _depthTotal;
    [SerializeField] private Text _moneyTotal;

	void Start () {
        _depthTotal.text = ScoreManager.Instance.depthCurrentRound.ToString("#.00") + "m";
        _moneyTotal.text = (ScoreManager.Instance.scoreCurrentRound * PlayerPrefs.GetInt("ItemValue")).ToString();
        if (ScoreManager.Instance.gainedEndObject > 0)
        {
            PlayerPrefs.SetInt("PhonesCollected",PlayerPrefs.GetInt("PhonesCollected")+ ScoreManager.Instance.gainedEndObject);
            PlayerPrefs.Save();
        }
        ScoreManager.Instance.ResetScore();
        _highscoreDepth.text = PlayerPrefs.GetFloat("HighScore").ToString("#.00") + "m";
	}
}
