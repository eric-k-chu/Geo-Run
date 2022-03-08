/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CrystalCountDisplay class, which contains
functions that display the player's crystal count to the screen
*/
using UnityEngine;
using UnityEngine.UI;

public class CrystalCountDisplay : MonoBehaviour
{
    [SerializeField] private Elements type;

    [SerializeField] private PlayerStats player_stats;

    private int crystal_count;

    private Slider ui_slider;

    private void Awake()
    {
        ui_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        crystal_count = 0;
    }

    private void Update()
    {
        if (type == Elements.Fire)
        {
            crystal_count = player_stats.GetFireCount();
        }
        else if (type == Elements.Water)
        {
            crystal_count = player_stats.GetWaterCount();
        }
        else if (type == Elements.Earth)
        {
            crystal_count = player_stats.GetEarthCount();
        }
        ui_slider.value = crystal_count;
    }
}
