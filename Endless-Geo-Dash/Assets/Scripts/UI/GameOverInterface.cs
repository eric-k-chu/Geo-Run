/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the GameOverInterface class, which handles the activation of the Game Over
menu.
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class GameOverInterface : MonoBehaviour
    {
        [SerializeField] private Animator game_over_menu;

        public void SetActiveGameOverMenu(bool value)
        {
            if (value)
            {
                game_over_menu.SetTrigger("ActiveGameOver");
            }
            else if (!value)
            {
                game_over_menu.SetTrigger("InactiveGameOver");
            }
        }
    }
}
