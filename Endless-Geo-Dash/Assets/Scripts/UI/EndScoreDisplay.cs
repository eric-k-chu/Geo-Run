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

namespace GPEJ.UI
{
    public class EndScoreDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject distance_traveled;

        [SerializeField] private GameObject final_score;

        [SerializeField] private GameObject crystal;

        [SerializeField] private GameObject high_score;

        private int distance;
        private int crystal_count;

        private float score_multiplier;

        private Text distance_traveled_text;
        private Text crystal_count_text;
        private Text final_score_text;


        private void Awake()
        {
            distance_traveled_text = distance_traveled.GetComponent<Text>();
            crystal_count_text = crystal.GetComponent<Text>();
            final_score_text = final_score.GetComponent<Text>();
        }

        private void Start()
        {
            GameStateManager.instance.OnPlayerDeath += SetDistanceTraveled;
            GameStateManager.instance.OnGameStateLost += DisplayScore;
            GameStateManager.instance.OnPlayerCrystalPickup += IncreaseCrystalCount;
            crystal_count = 0;
            score_multiplier = 1f;
            // highs_score.SetActive(true);
        }

        private void SetDistanceTraveled(int dist)
        {
            distance = dist;
        }

        private void DisplayScore(bool condition)
        {
            distance_traveled_text.text = distance.ToString() + " m";

            crystal_count_text.text = crystal_count.ToString();

            float total_score = distance * score_multiplier;

            if (PlayerPrefs.GetFloat(UserPref.instance.HighScore) < total_score)
            {
                PlayerPrefs.SetFloat(UserPref.instance.HighScore, total_score);
                // TODO: Display new high score msg
                // high_score.SetActive(true);
            }

            final_score_text.text = total_score.ToString();
        }

        private void IncreaseCrystalCount()
        {
            crystal_count++;
            score_multiplier += (crystal_count / 100f);
        }

        private void OnDestroy()
        {
            GameStateManager.instance.OnPlayerDeath -= SetDistanceTraveled;
            GameStateManager.instance.OnGameStateLost -= DisplayScore;
            GameStateManager.instance.OnPlayerCrystalPickup -= IncreaseCrystalCount;
        }
    }
}
