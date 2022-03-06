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

    private const float k_player_max_health = 100;
    private float player_health;

    private Slider ui_slider;

    private PlayerStats player_stats;

    private void Awake()
    {
        ui_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        ui_slider.maxValue = k_player_max_health;
        player_health = 100;
    }

    private void Update()
    {
        if (player_object == null)
        {
            player_object = GameObject.FindWithTag("Player");
            player_stats = player_object.GetComponent<PlayerStats>();
        }

        if (!GameStateManager.instance.IsPaused() && !GameStateManager.instance.IsLost())
        {
            player_health = player_stats.GetCurrentHealth();
            ui_slider.value = (player_health / k_player_max_health) * 100f;
        }
    }
}
