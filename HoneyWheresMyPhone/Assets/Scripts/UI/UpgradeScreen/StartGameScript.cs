﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

    /// <summary>
    /// loads the screen after the main menu scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
}
