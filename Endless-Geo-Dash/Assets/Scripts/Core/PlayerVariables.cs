/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the PlayerVariables class, which contains player movement variables
and the playable characters
*/

using UnityEngine;

namespace GPEJ
{
    [CreateAssetMenu(fileName = "New Player Variables", menuName = "Player Variables")]
    public class PlayerVariables : ScriptableObject
    {
        public float distance_between_lanes;
        public float forward_speed;
        public float horizontal_speed;
        public float jump_force;
        public float fall_multiplier; 
        public CharacterInfo[] character_list;     

        public string GetName()
        {
            if (character_list.Length == 0) return null;

            return character_list[PlayerPrefs.GetInt(Preference.CharacterType, 0)].character_name;
        }

        public Texture GetPortrait()
        {
            if (character_list.Length == 0) return null;

            return character_list[PlayerPrefs.GetInt(Preference.CharacterType, 0)].character_portrait;
        }
    }
}