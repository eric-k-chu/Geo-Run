/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the ScoreDisplay class, which will display
the player's current score on the screen.
*/
using UnityEngine;
using UnityEngine.UI;

namespace GPEJ.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        private int player_score;

        private Text ui_text;

        [SerializeField] private RuntimeDataContainer runtime_data;

        private void Awake()
        {
            ui_text = GetComponent<Text>();
        }

        private void Start()
        {
            player_score = 0;
            ui_text.text = player_score.ToString();
        }

        private void LateUpdate()
        {
            if (Time.timeScale != 0f)
            {
                ui_text.text = runtime_data.distance.ToString();
            }
        }
    }
}
