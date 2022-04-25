/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the CharacterInfo class, which contains
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
