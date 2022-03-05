/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameOverInterface class, which contains functions that allow the player
to interact with the GameOver GUI.
*/
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverInterface : MonoBehaviour
{
    private void Start()
    {
        GameStateManager.instance.OnGameStateLost += SetActiveGameOverMenu;
        gameObject.SetActive(false);
    }

    private void SetActiveGameOverMenu(bool value)
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
        GameStateManager.instance.OnGameStateLost -= SetActiveGameOverMenu;
    }

    public void Retry()
    {
        GameStateManager.instance.TerminateLostState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
