/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerStats class, which contains
information about certain ingame stats
*/
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance { get; private set; }

    [SerializeField] private GameSettings game_settings;

    private GameObject player_object;

    private float current_health;
    private int distance_traveled;
    private int fire_crystal_count;
    private int water_crystal_count;
    private int earth_crystal_count;

    private Ailments current_ailment;
    private float burning_multiplier;
    private float chilled_multiplier;
    private float grasped_multiplier;

    private void Awake()
    {
        instance = this;
    }

    public void ResetAllStats()
    {
        player_object = Instantiate(game_settings.GetGameObject());
        current_health = 100f;
        distance_traveled = fire_crystal_count = water_crystal_count = earth_crystal_count = 0;
        current_ailment = Ailments.None;
        burning_multiplier = chilled_multiplier = grasped_multiplier = 1f;
    }

    // Setters
    public void SetPlayerObject(GameObject obj)
    {
        player_object = obj;
    }

    public void SetCurrentHealth(float val)
    {
        current_health = val;
    }

    public void SetDistanceTraveled(int val)
    {
        distance_traveled = val;
    }

    public void SetFireCount(int val)
    {
        fire_crystal_count = val;
    }

    public void SetWaterCount(int val)
    {
        water_crystal_count = val;
    }

    public void SetEarthCount(int val)
    {
        earth_crystal_count = val;
    }

    public void SetCurrentAilment(Ailments ailment)
    {
        current_ailment = ailment;
    }

    public void SetBurnMultiplier(float val)
    {
        burning_multiplier = val;
    }

    public void SetChillMultiplier(float val)
    {
        chilled_multiplier = val;
    }

    public void SetGraspMultiplier(float val)
    {
        grasped_multiplier = val;
    }

    // Getters
    public GameObject GetPlayerObject()
    {
        return player_object;
    }

    public float GetCurrenHealth()
    {
        return current_health;
    }

    public int GetDistancedTraveled()
    {
        return distance_traveled;
    }

    public int GetFireCount()
    {
        return fire_crystal_count;
    }

    public int GetWaterCount()
    {
        return water_crystal_count;
    }

    public int GetEarthCount()
    {
        return earth_crystal_count;
    }

    public Ailments GetCurrentAilment()
    {
        return current_ailment;
    }

    public float GetBurnMultiplier()
    {
        return burning_multiplier;
    }

    public float GetChillMultiplier()
    {
        return chilled_multiplier;
    }

    public float GetGraspMultiplier()
    {
        return grasped_multiplier;
    }
}
