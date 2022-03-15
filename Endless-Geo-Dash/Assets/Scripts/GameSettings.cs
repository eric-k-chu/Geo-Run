/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the GameSettings scriptable object, which contains data about the game
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New User Settings", menuName = "Game Settings/User")]
public class GameSettings : ScriptableObject
{
    public float maximum_player_health;
    public float distance_between_lanes;
    public float forward_speed;
    public float horizontal_speed;
    public float jump_force;
    public float fall_multiplier;

    public Character[] character_list;


    public string GetName()
    {
        return character_list[PlayerPrefs.GetInt(UserPref.instance.CharacterType)].character_name;
    }

    public Sprite GetPortrait()
    {
        return character_list[PlayerPrefs.GetInt(UserPref.instance.CharacterType)].character_portrait;
    }
}
