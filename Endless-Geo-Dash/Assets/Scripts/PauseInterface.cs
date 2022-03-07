/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PauseInterface class, which contains functions that allow the player
to interact with the pause GUI.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInterface: MonoBehaviour
{
    private void Start()
    {
        GameStateManager.instance.OnPlayerPause += SetActivePauseMenu;
        gameObject.SetActive(false);
    }

    private void SetActivePauseMenu(bool value)
    {
        if (value)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnPlayerPause -= SetActivePauseMenu;
    }

    // Loads Main Menu Scene
    public void ToMainMenu()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadScene("Main Menu");
    }

    public void ToSettings()
    {
        SettingsInterface.instance.SetActiveSettingsMenu(true);
    }

    public void Retry()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Exits the application
    public void QuitGame()
    {
        GameStateManager.instance.TerminateLostState();
        Application.Quit();
    }
}
