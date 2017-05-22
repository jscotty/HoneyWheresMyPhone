using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreens : MonoBehaviour {

    public static TutorialScreens Instance;

    private static bool[] _screensDone = new bool[2] { false, false };

    [SerializeField]
    private Image _screenImage;

    [SerializeField]
    private Sprite[] _screenBackgrounds;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Shows the tutorial screen
    /// </summary>
    /// <param name="iScreen">0 is the "collect as many items as possible" screen. 1 is the "collect as many items as possible" screen.</param>
    public void ShowScreen(int iScreen)
    {
        if (iScreen < _screenBackgrounds.Length)
        {
            if (_screensDone[iScreen] == false)
            {
                gameObject.SetActive(true);
                _screenImage.sprite = _screenBackgrounds[iScreen];
                _screensDone[iScreen] = true;
                Time.timeScale = 0;
            }
        }
        else
        {
            Debug.LogError("There is no screen " + iScreen);
        }
    }

    /// <summary>
    /// Disables the tutorial screen
    /// </summary>
    public void DisableScreen()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
