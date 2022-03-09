/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SettingsInterface class, which contains functions
that allow the user to interact with the settings GUI
*/
using UnityEngine;

public class SettingsInterface : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SetActiveSettingsMenu(bool value)
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

    private void LateUpdate()
    {
        // Close the settings menu if ESC is pressed and settings menu is open
        if (gameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetActiveSettingsMenu(false);
            }
        }
    }
}
