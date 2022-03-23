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

namespace GPEJ.UI
{
    public class GameOverInterface : MonoBehaviour
    {
        [SerializeField] private Animator game_over_menu;

        [SerializeField] private Button[] buttons;

        public void SetActiveGameOverMenu(bool value)
        {
            if (value)
            {
                game_over_menu.SetTrigger("ActiveGameOver");
            }
            else if (!value)
            {
                game_over_menu.SetTrigger("InactiveGameOver");
                EnableInteractable();
            }
        }

        public void ToMainMenu()
        {
            SceneManager.LoadSceneAsync("Menu-Scene", LoadSceneMode.Single);

        }

        public void Retry()
        {
            SceneManager.LoadSceneAsync("Game-Scene", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        // Makes the game over menu buttons uninteractable
        public void DisableInteractable()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = false;
            }
        }

        // Makes the game over menu buttons interactable
        public void EnableInteractable()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].interactable = true;
            }
        }
    }
}
