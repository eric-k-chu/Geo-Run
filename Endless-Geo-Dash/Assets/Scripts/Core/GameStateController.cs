/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the GameStateController class, which keeps track of 
the player object and the current game state.
*/

using System.Collections;
using UnityEngine;

namespace GPEJ
{
    public enum GameState { Initial, Waiting, Running, Pause, Lost }
    
    public class GameStateController : MonoBehaviour
    {
        [Header("Event Channels")]
        [SerializeField] private BoolEventChannel player_pause_channel;

        [Header("Characters")]
        [SerializeField] private GameObject[] character_list;
        [SerializeField] private GameObject[] fractured_character_list;
        [SerializeField] private GameObject active_player;
        [SerializeField] private GameObject waiting_ui_canvas;
        [SerializeField] private float seconds_in_death_animation;
         
        private GameState current_state;
        private WaitForSeconds timer;
        
        private int character_type;
        private bool is_beginning_of_game = true;

        public void StartGame()
        {
            TransitionState(GameState.Waiting);
        }

        public void LoseGame(bool condition)
        {
            TransitionState(GameState.Lost);
        }

        public void UnpauseGame()
        {
            TransitionState(GameState.Waiting);
        }        

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                PlayerPrefs.SetInt(Preference.CharacterType, 0);
            }
        }

        private void Start()
        {
            character_type = PlayerPrefs.GetInt(Preference.CharacterType);
            //active_player = character_list[character_type];
            timer = new WaitForSeconds(seconds_in_death_animation);
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
                        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.P))
                        {
                            TransitionState(GameState.Running);
                        }

                        if (Input.GetKeyDown(KeyCode.P))
                        {
                            TransitionState(GameState.Pause);
                        }
                        break;
                    }
                case GameState.Running:
                    {
                        if (Input.GetKeyDown(KeyCode.P))
                        {
                            TransitionState(GameState.Pause);
                        }
                        break;
                    }
                case GameState.Pause:
                    {
                        if (Input.GetKeyDown(KeyCode.P))
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
                        var player = Instantiate(character_list[character_type], Vector3.zero, Quaternion.identity, active_player.transform);
                        player.transform.localPosition = Vector3.zero;
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
    }
}
