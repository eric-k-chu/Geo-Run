/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the RuntimeDataContainer class, which holds the 
values of player velocity, distance, and crystal count.
*/

using UnityEngine;

namespace GPEJ
{
    [CreateAssetMenu(menuName = "Data/Runtime Data")]
    public class RuntimeDataContainer : ScriptableObject
    {
        [HideInInspector] public float velocity;
        [HideInInspector] public float distance;
        [HideInInspector] public int crystals;
    }
}
