/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameStateController class, which keeps track of 
the player object and the current game state
*/
using System.Collections;
using UnityEngine;

namespace GPEJ
{
    public class GameStateController : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private BoolEventChannel player_pause_channel;

        [Header("Characters")]
        [SerializeField] private GameObject[] character_list;
        [SerializeField] private GameObject[] fractured_character_list;
        [SerializeField] private GameObject waiting_ui_canvas;

        [SerializeField] private float seconds_in_death_animation;
        private WaitForSeconds timer;

        private enum GameState { Initial, Waiting, Running, Pause, Lost }
        private GameState current_state;

        private GameObject active_player;

        private int character_type;

        private bool is_beginning_of_game;

        private const string k_character_type = "CharacterInfo-Type";


        private void Awake()
        {
            if (!PlayerPrefs.HasKey(k_character_type))
            {
                PlayerPrefs.SetInt(k_character_type, 0);
            }
        }

        private void Start()
        {
            character_type = PlayerPrefs.GetInt(k_character_type);
            active_player = character_list[character_type];
            timer = new WaitForSeconds(seconds_in_death_animation);
            is_beginning_of_game = true;
            TransitionState(GameState.Initial);
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
                        player_pause_channel.RaiseEvent(false);
                        break;
                    }
                case GameState.Lost:
                    break;
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
                        player_pause_channel.RaiseEvent(true);
                        break;
                    }
                case GameState.Lost:
                    {
                        Instantiate(fractured_character_list[character_type],
                            active_player.transform.position,
                            active_player.transform.rotation);
                        active_player.SetActive(false);
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
            Time.timeScale = 0f;
        }

        public void LoseGame(bool condition)
        {
            TransitionState(GameState.Lost);
        }
    }
}
