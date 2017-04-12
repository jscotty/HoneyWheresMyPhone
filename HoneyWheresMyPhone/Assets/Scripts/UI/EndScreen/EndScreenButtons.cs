using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenButtons : MonoBehaviour {

	public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void UpgradeMenu()
    {
        //SceneManager.LoadScene();
        //TODO add upgrade menu scene number
        Debug.Log("Add Upgrade menu scene number here");
    }
}
