/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the EndScoreDisplay class, which displays the ending score of the player.
*/

using TMPro;
using UnityEngine;

namespace GPEJ.UI
{
    public class EndScoreDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject distance_traveled;
        [SerializeField] private GameObject final_score;
        [SerializeField] private GameObject crystal;
        [SerializeField] private GameObject multiplier;
        [SerializeField] private GameObject high_score;
        [SerializeField] private RuntimeDataContainer runtime_data;

        private int distance;
        private int crystal_count;
        private float score_multiplier;

        private TextMeshProUGUI distance_text_mesh;
        private TextMeshProUGUI crystal_count_text_mesh;
        private TextMeshProUGUI final_score_text_mesh;
        private TextMeshProUGUI multiplier_text_mesh;

        private void Awake()
        {
            distance_text_mesh = distance_traveled.GetComponent<TextMeshProUGUI>();
            crystal_count_text_mesh = crystal.GetComponent<TextMeshProUGUI>();
            final_score_text_mesh = final_score.GetComponent<TextMeshProUGUI>();
            multiplier_text_mesh = multiplier.GetComponent<TextMeshProUGUI>();
            
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
            high_score.SetActive(false);
        }

        public void DisplayScore(bool condition)
        {
            crystal_count = runtime_data.crystals;
            score_multiplier += (crystal_count / 100f);
            distance = (int)runtime_data.distance;

            crystal_count_text_mesh.text = crystal_count.ToString();
            multiplier_text_mesh.text = score_multiplier.ToString();
            distance_text_mesh.text = distance.ToString() + " m";
            
            int total_score = (int)(distance * score_multiplier);
            final_score_text_mesh.text = total_score.ToString();

            if (PlayerPrefs.GetInt(Preference.HighScore) < total_score)
            {
                PlayerPrefs.SetInt(Preference.HighScore, total_score);
                high_score.SetActive(true);
            }          
        }
    }
}
