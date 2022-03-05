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

    [SerializeField] private UserSettings user_settings;

    // All of the available models the user can choose from
    [SerializeField] private GameObject[] character_list;

    private GameObject active_player_object;

    private enum GameState { Initial, Running, Pause, Lost }
    private GameState current_state;

    // Get the player's transform on spawn
    public event Action<Transform> OnPlayerSpawn;
    public void GetPlayerTransform (Transform player)
    {
        OnPlayerSpawn?.Invoke(player);
    }

    public event Action<bool> OnPlayerPause;
    public void SetActivePauseMenu(bool value)
    {
        OnPlayerPause?.Invoke(value);
    }

    public event Action OnPlayerDeath;
    public void EndGame()
    {
        OnPlayerDeath?.Invoke();
    }

    public event Action OnGameStateLost;
    public void ActivateGameOverMenu()
    {
        OnGameStateLost?.Invoke();
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        instance.OnPlayerDeath += TransitionToLostState;
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
                instance.SetActivePauseMenu(false);
                Time.timeScale = 1f;
                break;
            case GameState.Lost:
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
                Time.timeScale = 1f;
                SpawnPlayer();
                TransitionState(GameState.Running);
                break;
            case GameState.Running:
                break;
            case GameState.Pause:
                Time.timeScale = 0f;
                instance.SetActivePauseMenu(true);
                break;
            case GameState.Lost:
                // TODO: BRING UP PLAYER SCORE
                Time.timeScale = 0f;
                instance.ActivateGameOverMenu();
                break;
            default:
                break;
        }
    }

    // Spawns the player object at world origin (0,0,0)
    private void SpawnPlayer()
    {
        active_player_object = Instantiate(character_list[user_settings.character_type].gameObject);
        GameStateManager.instance.GetPlayerTransform(active_player_object.transform);
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

    // This function will be called when the player dies (called in PlayerStats.c)
    private void TransitionToLostState()
    {
        TransitionState(GameState.Lost);
    }

    // Unsubscribe from events on the deletion of this game object
    private void OnDestroy()
    {
        instance.OnPlayerDeath -= TransitionToLostState;
    }
}
