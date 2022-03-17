/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Character ScriptableObject, which contains variables
that make up the Character object
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Game Entities/Characters")]
public class Character : ScriptableObject
{
    public string character_name;
    public Texture character_portrait;
}
