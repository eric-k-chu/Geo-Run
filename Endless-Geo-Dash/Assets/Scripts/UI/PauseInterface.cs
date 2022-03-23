/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PauseInterface class, which contains functions that allow the player
to interact with the pause GUI.
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public class PauseInterface : MonoBehaviour
    {
        [SerializeField] private Animator pause_menu;

        [SerializeField] private Button[] buttons;

        public void SetActivePauseMenu(bool value)
        {
            if (value)
            {
                pause_menu.SetTrigger("Active");
                AudioManager.instance.PlayUIMenuAppear();
            }
            else
            {
                pause_menu.SetTrigger("Inactive");
                EnableInteractable();
            }
        }

        public void ToMainMenu()
        {
            SceneManager.LoadSceneAsync("Menu-Scene", LoadSceneMode.Single);
        }

        public void Retry()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        // Makes the pause menu buttons uninteractable
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
}
