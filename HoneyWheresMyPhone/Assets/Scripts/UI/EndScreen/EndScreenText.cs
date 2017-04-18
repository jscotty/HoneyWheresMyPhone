﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenText : MonoBehaviour {

    [SerializeField] private Text _highscoreDepth;
    [SerializeField] private Text _depthTotal;
    [SerializeField] private Text _moneyTotal;

	void Start () {
        _depthTotal.text = ScoreManager.Instance.depthCurrentRound.ToString("#.00") + "m";
        _moneyTotal.text = ScoreManager.Instance.scoreCurrentRound.ToString();
        ScoreManager.Instance.ResetScore();
        _highscoreDepth.text = ScoreManager.Instance.MeterHighscore.ToString("#.00") + "m";
	}
}