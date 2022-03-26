/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlayerVariables scriptable object, which contains variables that 
control player movement and health
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

        private const string k_character_type = "CharacterInfo-Type";

        public string GetName()
        {
            return character_list[PlayerPrefs.GetInt(k_character_type)].character_name;
        }

        public Texture GetPortrait()
        {
            return character_list[PlayerPrefs.GetInt(k_character_type)].character_portrait;
        }
    }
}