/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the HealthDisplay class, which contains
functions that display the player's current health to the screen
*/
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private GameObject player_object;

    private float player_health;

    private Text ui_text;

    private PlayerStats player_stats;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        player_health = 100;
    }

    private void Update()
    {
        if (player_object == null && !GameStateManager.instance.IsLost())
        {
            player_object = GameObject.FindWithTag("Player");
            player_stats = player_object.GetComponent<PlayerStats>();
        }

        if (!GameStateManager.instance.IsPaused())
        {
            player_health = player_stats.GetCurrentHealth();
            ui_text.text = player_health.ToString();
        }
    }
}
