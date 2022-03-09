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

    [SerializeField] private GameObject fire_crystal_count;

    [SerializeField] private GameObject water_crystal_count;

    [SerializeField] private GameObject earth_crystal_count;

    [SerializeField] private GameObject final_score;

    [SerializeField] private GameObject high_score;

    private Text distance_traveled_text;

    private Text fire_crystal_count_text;

    private Text water_crystal_count_text;

    private Text earth_crystal_count_text;

    private Text final_score_text;

    private void Awake()
    {
        distance_traveled_text = distance_traveled.GetComponent<Text>();
        fire_crystal_count_text = fire_crystal_count.GetComponent<Text>();
        water_crystal_count_text = water_crystal_count.GetComponent<Text>();
        earth_crystal_count_text = earth_crystal_count.GetComponent<Text>();
        final_score_text = final_score.GetComponent<Text>();
    }

    private void Start()
    {
        GameStateManager.instance.OnGameStateLost += DisplayScore;
        // highs_score.SetActive(true);
    }

    private void DisplayScore(bool val)
    {
        float dist = PlayerStats.instance.GetDistancedTraveled();
        float fire_count = PlayerStats.instance.GetFireCount();
        float water_count = PlayerStats.instance.GetWaterCount();
        float earth_count = PlayerStats.instance.GetEarthCount();

        distance_traveled_text.text = dist.ToString() + " m";
        fire_crystal_count_text.text = fire_count.ToString();
        water_crystal_count_text.text = water_count.ToString();
        earth_crystal_count_text.text = earth_count.ToString();

        float crystal_count = fire_count + water_count + earth_count;
        int total_score = (int)(dist * (1 + (crystal_count / 100f)));

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
        GameStateManager.instance.OnGameStateLost -= DisplayScore;     
    }
}
