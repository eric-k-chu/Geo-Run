/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the MainMenuInterface class, which contains
functions that allow the user to interact with the Menu GUI
*/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public class MainMenuInterface : MonoBehaviour
    {
        [SerializeField] private Animator logo_ac;
        [SerializeField] private Animator play_ac;
        [SerializeField] private Animator settings_ac;
        [SerializeField] private Animator quit_ac;
        [SerializeField] private GameObject menu_options_background;

        private void Start()
        {
            play_ac.gameObject.SetActive(false);
            settings_ac.gameObject.SetActive(false);
            quit_ac.gameObject.SetActive(false);
            menu_options_background.SetActive(false);
        }

        public void LoadGame()
        {
            SceneManager.LoadSceneAsync("Game-Scene", LoadSceneMode.Single);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void DisplayMenuOptions()
        {
            play_ac.gameObject.SetActive(true);
            play_ac.SetTrigger("Enter");
            settings_ac.gameObject.SetActive(true);
            settings_ac.SetTrigger("Enter");
            quit_ac.gameObject.SetActive(true);
            quit_ac.SetTrigger("Enter");
            menu_options_background.SetActive(true);
        }

        public void HideMenuOptions()
        {
            logo_ac.SetTrigger("Normal");

            play_ac.gameObject.SetActive(false);
            play_ac.SetTrigger("Exit");
            settings_ac.gameObject.SetActive(false);
            settings_ac.SetTrigger("Exit");
            quit_ac.gameObject.SetActive(false);
            quit_ac.SetTrigger("Exit");
            menu_options_background.SetActive(false);
        }
    }
}
