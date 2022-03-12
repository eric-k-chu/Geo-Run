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
using UnityEngine.SceneManagement;

public class MainMenuInterface : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("Game-Scene", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
