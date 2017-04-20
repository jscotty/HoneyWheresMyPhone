using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour {

    /// <summary>
    /// reloads the current scene
    /// </summary>
	public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// loads the main menu
    /// </summary>
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// open the upgrade screen
    /// </summary>
    public void UpgradeMenu()
    {
        //SceneManager.LoadScene();
        //TODO add upgrade menu scene number
        Debug.Log("Add Upgrade menu scene number here");
    }
}
