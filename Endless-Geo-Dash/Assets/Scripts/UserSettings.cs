/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the UserSettings scriptable object, which contains data about the user
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New User Settings", menuName = "Game Settings/User")]
public class UserSettings : ScriptableObject
{
    [Range(0,1)]
    public int character_type;

    [Range(0,100)]
    public float volume;
}
