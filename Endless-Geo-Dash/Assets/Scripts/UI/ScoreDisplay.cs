/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the ScoreDisplay class, which will display the player's current score on 
the screen.
*/

using TMPro;
using UnityEngine;

namespace GPEJ.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private RuntimeDataContainer runtime_data;

        private TextMeshProUGUI text_mesh;

        private void Awake()
        {
            text_mesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            int starting_score = 0;
            text_mesh.text = starting_score.ToString();
        }

        private void LateUpdate()
        {
            if (Time.timeScale != 0f)
            {
                text_mesh.text = ((int)(runtime_data.distance)).ToString();
            }
        }
    }
}
