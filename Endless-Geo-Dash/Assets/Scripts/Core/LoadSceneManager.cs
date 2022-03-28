/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the LoadSceneManager class, which will
asynchronously load the scene specified by SceneLoader class
*/
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ
{
    public class LoadSceneManager : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync(SceneLoader.SceneToLoad);
        }
    }
}
