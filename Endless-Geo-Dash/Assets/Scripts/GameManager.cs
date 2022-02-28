using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    private Transform player_object;

    public event Action<Transform> OnPlayerSpawn;
    public void GetPlayerTransform(Transform player)
    {
        OnPlayerSpawn?.Invoke(player);
    }

    private enum GameState { Initial, Running, Pause, Resuming, Lost }
    private GameState current_state;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameManager.instance.OnPlayerSpawn += ReceivePlayerTransform;
        current_state = GameState.Initial;
    }

    private void Update()
    {
        switch (current_state)
        {
            case GameState.Initial:
                break;
            case GameState.Running:
                break;
            case GameState.Pause:
                break;
            case GameState.Resuming:
                break;
            case GameState.Lost:
                break;
            default:
                break;
        }
    }

    private void TransitionState (GameState state)
    {
        current_state = state;
    }

    // This function receives the player's transform from PlayerController.ConnecToGameManager
    private void ReceivePlayerTransform(Transform player)
    {
        player_object = player;
    }

    private void OnDestroy()
    {
        GameManager.instance.OnPlayerSpawn -= ReceivePlayerTransform;
    }
}
