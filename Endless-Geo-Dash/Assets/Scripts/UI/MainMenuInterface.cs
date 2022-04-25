/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the MainMenuInterface class, handles the button interactability.
*/

using UnityEngine;
using UnityEngine.UI;

namespace GPEJ.UI
{
    public class MainMenuInterface : MonoBehaviour
    {
        [SerializeField] private Button[] menu_buttons;

        // Changes the interactable option of each button in the menu
        public void SetInteractable(bool condition)
        {
            for (int i = 0; i < menu_buttons.Length; i++)
            {
                menu_buttons[i].interactable = condition;
            }
        }
    }
}
