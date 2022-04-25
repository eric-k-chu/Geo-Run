/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the PauseInterface class, which handles the activation of the pause menu.
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class PauseInterface : MonoBehaviour
    {
        [SerializeField] private Animator pause_menu;

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
            }
        }
    }
}
