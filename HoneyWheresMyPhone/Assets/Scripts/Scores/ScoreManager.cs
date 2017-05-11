using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager> {
    
    public int scoreCurrentRound = 0;
    public float depthCurrentRound = 0;
    public bool gainedEndObject = false;

    public void ResetScore()
    {
        if(depthCurrentRound > PlayerPrefs.GetFloat("HighScore")) {
            PlayerPrefs.SetFloat("HighScore", depthCurrentRound);
        }
        PlayerPrefs.SetFloat("MoneyTotal", PlayerPrefs.GetFloat("MoneyTotal") + (scoreCurrentRound * PlayerPrefs.GetInt("ItemValue")));
        scoreCurrentRound = 0;
        depthCurrentRound = 0;
    }
}
