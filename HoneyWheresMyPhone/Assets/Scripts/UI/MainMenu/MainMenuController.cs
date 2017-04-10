using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void StartGame()
    {
        //TODO check if the GameScene actually will be scene 1
        SceneManager.LoadScene(1);
    }
}
