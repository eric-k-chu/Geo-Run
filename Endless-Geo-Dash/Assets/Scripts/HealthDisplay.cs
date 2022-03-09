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
    [SerializeField] private GameSettings game_settings;

    private float player_max_health;
    private float player_health;

    private Slider ui_slider;


    private void Awake()
    {
        ui_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        player_max_health = game_settings.maximum_player_health;
        ui_slider.maxValue = player_max_health;
        player_health = player_max_health;
    }

    private void Update()
    {
        if (!GameStateManager.instance.IsPaused() && !GameStateManager.instance.IsLost())
        {
            player_health = PlayerStats.instance.GetCurrenHealth();
            ui_slider.value = (player_health / player_max_health) * 100f;
        }
    }
}
