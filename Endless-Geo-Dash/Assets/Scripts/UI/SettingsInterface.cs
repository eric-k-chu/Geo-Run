/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the SettingsInterface class, handles the activation of the settings menu.
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

        // Close out of settings menu when player presses Pause
        public void HideSettingsMenu(bool value)
        {
            if (!value)
            {
                SetActiveSettingsMenu(value);
            }
        }
    }
}
