/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameOverInterface class, which contains functions that allow the player
to interact with the GameOver GUI.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverInterface : MonoBehaviour
{
    [SerializeField] private Animator game_over_menu;

    [SerializeField] private Button[] buttons;

    private void Start()
    {
        GameStateManager.instance.OnGameStateLost += SetActiveGameOverMenu;
    }

    private void SetActiveGameOverMenu(bool value)
    {
        if (value)
        {
            game_over_menu.SetTrigger("ActiveGameOver");
        } 
        else
        {
            Debug.Log("Game Over Inactive");
            game_over_menu.SetTrigger("InactiveGameOver");
            EnableInteractable();
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
        SceneManager.LoadSceneAsync("Menu-Scene", LoadSceneMode.Single);

    }

    // Restarts the Game
    public void Retry()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadSceneAsync("Game-Scene", LoadSceneMode.Single);
    }

    // Exits the application
    public void QuitGame()
    {
        GameStateManager.instance.TerminateLostState();
        Application.Quit();
    }

    public void DisableInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
    }

    // Makes the pause menu buttons interactable
    public void EnableInteractable()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
        }
    }
}
