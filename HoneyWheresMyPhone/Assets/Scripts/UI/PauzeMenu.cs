using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauzeMenu : MonoBehaviour {

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
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
