using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour {

    /// <summary>
    /// Pauses th game and shows the pause menu
    /// </summary>
    /// <param name="iPauzeMenu"></param>
	public void OnButtonPressed(GameObject iPauzeMenu)
    {
        if (iPauzeMenu.activeInHierarchy)
        {
            iPauzeMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            iPauzeMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// loads the main menu scene
    /// </summary>
    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
