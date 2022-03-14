/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameOverInterface class, which contains functions that allow the player
to interact with the GameOver GUI.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInterface : MonoBehaviour
{
    [SerializeField] private Animator game_over_menu;

    private void Start()
    {
        GameStateManager.instance.OnGameStateLost += SetActiveGameOverMenu;
    }

    private void SetActiveGameOverMenu(bool value)
    {
        if (value)
        {
            game_over_menu.SetTrigger("Active");
        } 
        else
        {
            game_over_menu.SetTrigger("Inactive");
        }
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnGameStateLost -= SetActiveGameOverMenu;
    }

    // Loads Main Menu Scene
    public void ToMainMenu()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    }

    // Restarts the Game
    public void Retry()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    // Exits the application
    public void QuitGame()
    {
        GameStateManager.instance.TerminateLostState();
        Application.Quit();
    }
}
