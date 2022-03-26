/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PauseInterface class, which contains functions that allow the player
to interact with the pause GUI.
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
