using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public class UIButtonController : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel game_start_channel;

        private CanvasGroup black_screen_canvas;

        private void Awake()
        {
            black_screen_canvas = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            StartCoroutine(FadeIntoCurrentScene());
        }

        public void LoadMainMenu()
        {
            gameObject.SetActive(true);
            Time.timeScale = 1f;
            StartCoroutine(FadeIntoLoadingScreen("Menu-Scene"));
        }

        public void LoadGame()
        {
            gameObject.SetActive(true);
            Time.timeScale = 1f;
            StartCoroutine(FadeIntoLoadingScreen("Game-Scene"));
        }

        private IEnumerator FadeIntoLoadingScreen(string scene_name)
        {
            float start_alpha = 0f;
            float time = 0f;
            while (time < 1f)
            {
                black_screen_canvas.alpha = Mathf.Lerp(start_alpha, 1, time / 1f);
                time += Time.deltaTime;
                yield return null;
            }
            black_screen_canvas.alpha = 1;
            SceneLoader.scene_to_load = scene_name;
            SceneManager.LoadScene("Load-Scene");
        }

        private IEnumerator FadeIntoCurrentScene()
        {
            float start_alpha = 1f;
            float time = 0f;
            while (time < 1f)
            {
                black_screen_canvas.alpha = Mathf.Lerp(start_alpha, 0, time / 1f);
                time += Time.deltaTime;
                yield return null;
            }
            black_screen_canvas.alpha = 1;
            gameObject.SetActive(false);
            game_start_channel.RaiseEvent();
        }
    }
}
