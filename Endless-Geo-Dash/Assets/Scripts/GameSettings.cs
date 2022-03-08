/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameSettings scriptable object, which contains data about the user
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New User Settings", menuName = "Game Settings/User")]
public class GameSettings : ScriptableObject
{
    [Header("Player Controlled Settings")]
    [Range(0, 2)]
    public int character_type;

    [Range(0, 1)]
    public float master_volume;

    [Range(0, 1)]
    public float music_volume;

    [Range(0, 1)]
    public float sfx_volume;

    [Range(0, 1)]
    public float ui_volume;

    [Header("Dev Controlled Settings")]
    public float maximum_player_health;

    public Character[] character_list;

    public GameObject GetGameObject()
    {
        return character_list[character_type].character_model;
    }

    public string GetName()
    {
        return character_list[character_type].character_name;
    }

    public Sprite GetPortrait()
    {
        return character_list[character_type].character_portrait;
    }
}
