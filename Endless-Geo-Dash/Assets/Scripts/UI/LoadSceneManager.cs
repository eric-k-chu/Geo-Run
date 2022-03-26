/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the LoadSceneManager class, which will
asynchronously load the scene specified by SceneLoader class
*/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GPEJ
{
    public class LoadSceneManager : MonoBehaviour
    {
        private Image progress_bar;

        private AsyncOperation loading_progress;
        private void Awake()
        {
            progress_bar = GetComponent<Image>();
        }

        private void Start()
        {
            loading_progress = SceneManager.LoadSceneAsync(SceneLoader.scene_to_load);
            Debug.Log(loading_progress.progress);
        }

        private void Update()
        {
            progress_bar.fillAmount = Mathf.Clamp01(loading_progress.progress / 0.9f);
        }
    }
}
