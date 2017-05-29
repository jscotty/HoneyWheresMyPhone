using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour {

    [SerializeField]
    private Animator _animator;

    private bool CheckForInput = false;

#if UNITY_EDITOR
    /// <summary>
    /// Sets the Animator in the editor
    /// </summary>
    private void Reset()
    {
        _animator = GetComponent<Animator>();
    }
#endif

    /// <summary>
    /// If the boolean is true this function will check if there is input. And if there is input, it will resume the game
    /// </summary>
    private void Update()
    {
        if (CheckForInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ResumeAnimation();
            }
            else if(Input.touchCount > 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    if(Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        ResumeAnimation();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Pauzes the animation. Will be activated by animation events.
    /// </summary>
    private void PauzeAnimation()
    {
        CheckForInput = true;
        _animator.speed = 0;
    }

    /// <summary>
    /// Resumes the animation and disables the input check
    /// </summary>
    private void ResumeAnimation()
    {
        _animator.speed = 1;
        CheckForInput = false;
    }

    /// <summary>
    /// Swaps the current scene to the Main Menu
    /// </summary>
    public void ToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
