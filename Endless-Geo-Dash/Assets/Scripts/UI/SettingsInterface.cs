/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SettingsInterface class, which contains functions
that allow the user to interact with the settings GUI
*/
using UnityEngine;

namespace GPEJ.UI
{
    public class SettingsInterface : MonoBehaviour
    {
        [SerializeField] private Animator settings_menu;

        public void SetActiveSettingsMenu(bool value)
        {
            if (value)
            {
                settings_menu.SetTrigger("ActiveSettings");
                AudioManager.instance.PlayUIMenuAppear();
            }
            else
            {
                settings_menu.SetTrigger("InactiveSettings");
            }
        }

        // Close out of settings menu when player presses ESC
        public void HideSettingsMenu(bool value)
        {
            if (!value)
            {
                SetActiveSettingsMenu(value);
            }
        }
    }
}
