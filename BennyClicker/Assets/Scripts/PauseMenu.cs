using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject game;
    bool isPaused = false;

    public void Continue()
    {
        game.SetActive(true);
        pauseMenu.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        game.SetActive(false);
        pauseMenu.SetActive(true);
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.P))
        {
            Pause();
        }
    }
}
