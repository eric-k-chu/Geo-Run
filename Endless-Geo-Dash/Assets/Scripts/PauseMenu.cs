/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PauseMenu class, which contains functions that allow the player
to interact with the Pause interface menu.
*/
using UnityEngine;

public class PauseMenu : MonoBehaviour
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
