/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the SceneLoader class, which controls which scene to transition to.
*/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel game_start_channel;

        private CanvasGroup black_screen_canvas;

        private float fade_duration = 0.5f;

        private void Awake()
        {
            black_screen_canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(FadeOutBlackScreen());
        }

        public void LoadMainMenu()
        {
            gameObject.SetActive(true);
            Time.timeScale = 1f;
            StartCoroutine(FadeIntoLoadingScreen(SceneNames.MainMenu));
        }

        public void LoadGame()
        {
            gameObject.SetActive(true);
            Time.timeScale = 1f;
            StartCoroutine(FadeIntoLoadingScreen(SceneNames.Game));
        }

        private IEnumerator FadeIntoLoadingScreen(string scene_name)
        {
            float start_alpha = 0f;
            float time = 0f;
            while (time < fade_duration)
            {
                black_screen_canvas.alpha = Mathf.Lerp(start_alpha, 1, time / fade_duration);
                time += Time.unscaledDeltaTime;
                yield return null;
            }
            black_screen_canvas.alpha = 1;
            SceneNames.SceneToLoad = scene_name;
            SceneManager.LoadScene(SceneNames.Load);
        }

        private IEnumerator FadeOutBlackScreen()
        {
            float start_alpha = 1f;
            float time = 0f;
            while (time < fade_duration)
            {
                black_screen_canvas.alpha = Mathf.Lerp(start_alpha, 0, time / fade_duration);
                time += Time.unscaledDeltaTime;
                yield return null;
            }
            black_screen_canvas.alpha = 0;
            gameObject.SetActive(false);
            game_start_channel.RaiseEvent();
        }
    }
}
