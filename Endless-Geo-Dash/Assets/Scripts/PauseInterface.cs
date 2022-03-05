/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PauseInterface class, which contains functions that allow the player
to interact with the pause GUI.
*/
using UnityEngine;

public class PauseInterface: MonoBehaviour
{
    private void Start()
    {
        GameStateManager.instance.OnPlayerPause += SetActivePauseMenu;
        gameObject.SetActive(false);
    }

    private void SetActivePauseMenu(bool value)
    {
        if (value)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnPlayerPause -= SetActivePauseMenu;
    }
}
