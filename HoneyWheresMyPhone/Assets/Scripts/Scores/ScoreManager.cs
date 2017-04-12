using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager> {

	public int ScoreTotal { get; private set; }
    public float MeterHighscore { get; private set; }
    public int scoreCurrentRound = 0;
    public float depthCurrentRound = 0;
    public bool gainedEndObject = false;

    private void Start()
    {
        UpdateHighScore();
    }

    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            MeterHighscore = PlayerPrefs.GetFloat("HighScore");
        }
    }

    public void ResetScore()
    {
        Debug.Log(scoreCurrentRound);
        if(depthCurrentRound > MeterHighscore) {
            PlayerPrefs.SetFloat("HighScore", depthCurrentRound);
        }
        UpdateHighScore();
        ScoreTotal += scoreCurrentRound;
        scoreCurrentRound = 0;
    }
}
