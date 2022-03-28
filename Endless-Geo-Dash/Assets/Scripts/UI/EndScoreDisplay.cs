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
        [SerializeField] private RuntimeDataContainer runtime_data;

        private int distance;
        private int crystal_count;
        private float score_multiplier;
        private Text distance_traveled_text;
        private Text crystal_count_text;
        private Text final_score_text;

        public void DisplayScore(bool condition)
        {
            crystal_count = runtime_data.crystals;
            score_multiplier += (crystal_count / 100f);
            distance = (int)runtime_data.distance;

            distance_traveled_text.text = distance.ToString() + " m";

            crystal_count_text.text = crystal_count.ToString();

            int total_score = (int)(distance * score_multiplier);

            if (PlayerPrefs.GetInt(Preference.HighScore) > total_score)
            {
                PlayerPrefs.SetInt(Preference.HighScore, total_score);
                high_score.SetActive(true);
            }

            final_score_text.text = total_score.ToString();
        }

        private void Awake()
        {
            distance_traveled_text = distance_traveled.GetComponent<Text>();
            crystal_count_text = crystal.GetComponent<Text>();
            final_score_text = final_score.GetComponent<Text>();

            if (!PlayerPrefs.HasKey(Preference.HighScore))
            {
                PlayerPrefs.SetInt(Preference.HighScore, 0);
            }
        }

        private void Start()
        {
            crystal_count = 0;
            score_multiplier = 1f;
            distance = 0;
        }
    }
}
