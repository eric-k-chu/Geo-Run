/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the LoadSceneManager class, which will
asynchronously load the scene specified by SceneNames class.
*/

using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ
{
    public class LoadSceneManager : MonoBehaviour
    {
        private void Start()
        {
            SceneManager.LoadSceneAsync(SceneNames.SceneToLoad);
        }
    }
}
