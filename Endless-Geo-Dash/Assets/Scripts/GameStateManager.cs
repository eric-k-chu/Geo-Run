/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameStateManager class, which keeps track of the user and the current game state
*/
using System;
using System.Collections;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance { get; private set; }

    [SerializeField] private GameObject[] character_list;

    private enum GameState { Initial, Running, Pause, Lost }
    private GameState current_state;

    public event Action<bool> OnPlayerPause;
    public void ShowPauseMenu(bool value)
    {
        OnPlayerPause?.Invoke(value);
    }

    public event Action<bool> OnGameStateLost;
    public void ShowGameMenu(bool value)
    {
        OnGameStateLost?.Invoke(value);
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerStats.instance.ResetAllStats();
        TransitionState(GameState.Initial);
    }

    private void Update()
    {
        switch (current_state)
        {
            case GameState.Initial:
                break;
            case GameState.Running:

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(GameState.Pause);
                }

                break;
            case GameState.Pause:

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    TransitionState(GameState.Running);
                }

                break;
            case GameState.Lost:
                break;
            default:
                break;
        }
    }

    // Transition to a new game state given a GameState obj param
    private void TransitionState (GameState state)
    {
        TerminateState(current_state);
        ActivateState(state);
    }

    // Performs the necessary functions on exiting a game state given a GameState obj param
    private void TerminateState(GameState state)
    {
        switch (state)
        {
            case GameState.Initial:
                break;
            case GameState.Running:
                break;
            case GameState.Pause:
                ShowPauseMenu(false);
                Time.timeScale = 1f;
                break;
            case GameState.Lost:
                ShowGameMenu(false);
                Time.timeScale = 1f;
                break;
            default:
                break;
        }
    }


    // Performs the necessary functions on entering a game state given a GameState obj param
    private void ActivateState(GameState state)
    {
        current_state = state;
        switch (current_state)
        {
            case GameState.Initial:

                GameObject player = character_list[PlayerPrefs.GetInt(UserPref.instance.CharacterType)];
                player.SetActive(true);
                Time.timeScale = 1f;
                TransitionState(GameState.Running);
                break;
            case GameState.Running:
                break;
            case GameState.Pause:
                Time.timeScale = 0f;
                ShowPauseMenu(true);
                break;
            case GameState.Lost:         
                Time.timeScale = 0f;
                ShowGameMenu(true);
                break;
            default:
                break;
        }
    }

    // Returns true if current game state is Pause, otherwise false
    public bool IsPaused()
    {
        if (current_state == GameState.Pause)
        {
            return true;
        }
        return false;
    }

    // Returns true if current game state is Lost, otherwise false
    public bool IsLost()
    {
        if (current_state == GameState.Lost)
        {
            return true;
        }
        return false;
    }

    // Returns true if current game state is Running, otherwise false
    public bool isRunning()
    {
        if (current_state == GameState.Running)
        {
            return true;
        }
        return false;
    }

    public void TerminateLostState()
    {
        TerminateState(current_state);
    }

    public void TransitionToLostState()
    {
        TransitionState(GameState.Lost);
    }
}
