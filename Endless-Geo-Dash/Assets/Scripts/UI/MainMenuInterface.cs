/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the MainMenuInterface class, which contains
functions that allow the user to interact with the Menu GUI
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
