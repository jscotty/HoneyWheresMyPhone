using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

    /// <summary>
    /// loads the screen after the main menu scene
    /// </summary>
    public void StartGame()
    {
        //TODO check if the GameScene actually will be scene 1
        SceneManager.LoadScene(1);
    }
}
