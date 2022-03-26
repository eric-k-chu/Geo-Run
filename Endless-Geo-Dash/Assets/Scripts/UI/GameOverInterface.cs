/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameOverInterface class, which contains functions that allow the player
to interact with the GameOver GUI.
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
