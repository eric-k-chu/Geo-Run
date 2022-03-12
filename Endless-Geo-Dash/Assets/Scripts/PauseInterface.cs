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
            AudioManager.instance.PlayUIMenuAppear();
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
        SceneManager.LoadSceneAsync("Menu-Scene", LoadSceneMode.Single);
    }

    public void Retry()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    // Exits the application
    public void QuitGame()
    {
        GameStateManager.instance.TerminateLostState();
        Application.Quit();
    }
}
