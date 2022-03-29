/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CharacterInfo ScriptableObject, which has
the character name and character sprite image
*/
using UnityEngine;

namespace GPEJ
{
    [CreateAssetMenu(fileName = "New CharacterInfo", menuName = "Character Info")]
    public class CharacterInfo : ScriptableObject
    {
        public string character_name;
        public Texture character_portrait;
    }
}
