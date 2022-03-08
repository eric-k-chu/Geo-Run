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
    [SerializeField] private bool is_fire;
    [SerializeField] private bool is_water;
    [SerializeField] private bool is_earth;

    private GameObject player_object;
    private AilmentCalcuation player_stats;

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
        if (player_object == null)
        {
            player_object = GameObject.FindWithTag("Player");
            player_stats = player_object.GetComponent<AilmentCalcuation>();
        }

        if (is_fire)
        {
            crystal_count = player_stats.GetFireCrystalCount();
        }
        else if (is_water)
        {
            crystal_count = player_stats.GetWaterCrystalCount();
        }
        else if (is_earth)
        {
            crystal_count = player_stats.GetEarthCrystalCount();
        }
        ui_slider.value = crystal_count;
    }
}
