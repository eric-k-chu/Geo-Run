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

public class ScoreDisplay : MonoBehaviour
{
    private int player_score;

    private Text ui_text;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        player_score = 0;
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsPaused() && !GameStateManager.instance.IsLost())
        {
            // player's score will increase as they keep moving forward (z axis)
            player_score = PlayerStats.instance.GetDistancedTraveled();
            ui_text.text = player_score.ToString();
        }
    }
}
