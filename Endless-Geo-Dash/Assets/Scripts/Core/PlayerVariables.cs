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

        public string GetName()
        {
            if (character_list.Length == 0) return null;

            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                return character_list[0].character_name;
            }
            return character_list[PlayerPrefs.GetInt(Preference.CharacterType)].character_name;
        }

        public Texture GetPortrait()
        {
            if (character_list.Length == 0) return null;

            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                return character_list[0].character_portrait;
            }
            return character_list[PlayerPrefs.GetInt(Preference.CharacterType)].character_portrait;
        }
    }
}