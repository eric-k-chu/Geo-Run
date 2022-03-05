/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameOverInterface class, which contains functions that allow the player
to interact with the GameOver GUI.
*/
using UnityEngine;

public class GameOverInterface : MonoBehaviour
{
    private void Start()
    {
        GameStateManager.instance.OnGameStateLost += ActivateGameOverMenu;
        gameObject.SetActive(false);
    }

    private void ActivateGameOverMenu()
    {
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnGameStateLost -= ActivateGameOverMenu;
    }
}
