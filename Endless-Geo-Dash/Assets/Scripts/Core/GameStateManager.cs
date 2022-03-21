/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameStateManager class, which keeps track of 
the player object and the current game state
*/
using System;
using System.Collections;
using UnityEngine;

namespace GPEJ
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] character_list;
        [SerializeField] private GameObject[] fractured_character_list;
        [SerializeField] private GameObject waiting_ui_canvas;

        [SerializeField] private float seconds_in_death_animation;
        private WaitForSeconds timer;

        public static GameStateManager instance { get; private set; }

        private enum GameState { Initial, Waiting, Running, Pause, Lost }
        private GameState current_state;

        private GameObject active_player;

        private int character_type;

        private bool is_beginning_of_game;
       
        public event Action<bool> OnPlayerPause;
        public event Action<bool> OnGameStateLost;
        public event Action<int> OnPlayerMoveForward;
        public event Action<float> OnPlayerVelocityIncrease;
        public event Action<int> OnPlayerDeath;
        public event Action OnPlayerCrystalPickup;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            character_type = PlayerPrefs.GetInt(UserPref.instance.CharacterType);
            active_player = character_list[character_type];
            TransitionState(GameState.Initial);
            timer = new WaitForSeconds(seconds_in_death_animation);
            is_beginning_of_game = true;
        }

        private void Update()
        {
            switch (current_state)
            {
                case GameState.Initial:
                    break;
                case GameState.Waiting:
                    {
                        if (Input.anyKeyDown)
                        {
                            TransitionState(GameState.Running);
                        }
                        break;
                    }
                case GameState.Running:
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            TransitionState(GameState.Pause);
                        }
                        break;
                    }
                case GameState.Pause:
                    {
                        if (Input.GetKeyDown(KeyCode.Escape))
                        {
                            TransitionState(GameState.Waiting);
                        }
                        break;
                    }
                case GameState.Lost:
                    break;
                default:
                    break;
            }
        }

        private void TransitionState(GameState state)
        {
            TerminateState(current_state);
            ActivateState(state);
        }

        private void TerminateState(GameState state)
        {
            switch (state)
            {
                case GameState.Initial:
                    break;
                case GameState.Waiting:
                    {
                        Time.timeScale = 1f;
                        waiting_ui_canvas.SetActive(false);
                        if (is_beginning_of_game)
                        {
                            AudioManager.instance.PlayMusic();
                            is_beginning_of_game = false;
                        }
                        else
                        {
                            AudioManager.instance.ResumeMusic();
                        }
                        break;
                    }
                case GameState.Running:
                    break;
                case GameState.Pause:
                    {
                        ShowPauseMenu(false);
                        break;
                    }
                case GameState.Lost:
                    {
                        ShowGameOverMenu(false);
                        Time.timeScale = 1f;
                        break;
                    }
                default:
                    break;
            }
        }

        private void ActivateState(GameState state)
        {
            current_state = state;
            switch (current_state)
            {
                case GameState.Initial:
                    {
                        active_player.SetActive(true);
                        Time.timeScale = 1f;
                        TransitionState(GameState.Waiting);
                        break;
                    }
                case GameState.Waiting:
                    {
                        Time.timeScale = 0f;
                        waiting_ui_canvas.SetActive(true);
                        break;
                    }
                case GameState.Running:
                    break;
                case GameState.Pause:
                    {
                        Time.timeScale = 0f;
                        AudioManager.instance.PauseMusic();
                        ShowPauseMenu(true);
                        break;
                    }
                case GameState.Lost:
                    {
                        Instantiate(fractured_character_list[character_type],
                            active_player.transform.position,
                            active_player.transform.rotation);
                        active_player.SetActive(false);
                        ShowGameOverMenu(true);
                        StopTime();
                        break;
                    }
                default:
                    break;
            }
        }

        private void StopTime()
        {
            StartCoroutine(PauseTimeAfterSeconds());
        }

        private IEnumerator PauseTimeAfterSeconds()
        {
            yield return timer;
            ShowGameOverMenu(true);
            Time.timeScale = 0f;
        }

        public bool IsLost()
        {
            return (current_state == GameState.Lost) ? true : false;
        }

        public void ShowPauseMenu(bool condition)
        {
            OnPlayerPause?.Invoke(condition);
        }

        public void ShowGameOverMenu(bool condition)
        {
            OnGameStateLost?.Invoke(condition);
        }

        public void UpdateVelocityInUI(float velocity)
        {
            OnPlayerVelocityIncrease?.Invoke(velocity);
        }

        public void UpdateScoreInUI(int distance)
        {
            OnPlayerMoveForward?.Invoke(distance);
        }

        public void SetFinalDistanceTraveled(int distance)
        {
            OnPlayerDeath?.Invoke(distance);
        }

        public void UpdateCrystalInUI()
        {
            OnPlayerCrystalPickup?.Invoke();
        }

        public void EndGameStateManager()
        {
            TerminateState(current_state);
        }

        public void LoseGame()
        {
            TransitionState(GameState.Lost);
        }
    }
}
