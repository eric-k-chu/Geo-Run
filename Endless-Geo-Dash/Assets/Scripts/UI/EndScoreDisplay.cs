/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the EndScoreDisplay class, which displays the ending score
of the player
*/
using UnityEngine;
using UnityEngine.UI;

public class EndScoreDisplay : MonoBehaviour
{
    [SerializeField] private GameObject distance_traveled;

    [SerializeField] private GameObject final_score;

    [SerializeField] private GameObject high_score;

    private int distance;

    private Text distance_traveled_text;

    private Text final_score_text;

    private void Awake()
    {
        distance_traveled_text = distance_traveled.GetComponent<Text>();
        final_score_text = final_score.GetComponent<Text>();
    }

    private void Start()
    {
        GameStateManager.instance.OnPlayerDeath += SetDistanceTraveled;
        GameStateManager.instance.OnGameStateLost += DisplayScore;
        // highs_score.SetActive(true);
    }

    private void SetDistanceTraveled(int value)
    {
        distance = value;
    }

    private void DisplayScore(bool value)
    {
        distance_traveled_text.text = distance.ToString() + " m";

        int total_score = distance;

        if (PlayerPrefs.GetInt(UserPref.instance.HighScore) < total_score)
        {
            PlayerPrefs.SetInt(UserPref.instance.HighScore, total_score);
            // TODO: Display new high score msg
            // high_score.SetActive(true);
        }

        final_score_text.text = total_score.ToString();
    }


    private void OnDestroy()
    {
        GameStateManager.instance.OnPlayerDeath -= SetDistanceTraveled;
        GameStateManager.instance.OnGameStateLost -= DisplayScore;     
    }
}
