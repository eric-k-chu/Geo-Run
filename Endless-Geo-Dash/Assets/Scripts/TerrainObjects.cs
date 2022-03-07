/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the TerrainObjects scriptableobject, which contains
the various background, platform, and checkpoint objects in the game
*/
using UnityEngine;

[CreateAssetMenu(fileName = "New TerrainObjects", menuName = "Game Objects/TerrainObjects")]
public class TerrainObjects : ScriptableObject
{
    [Header("Background")]
    public GameObject background_object;
    public float background_object_length;

    [Header("Checkpoint")]
    public GameObject checkpoint_object;
    public float checkpoint_object_length;

    [Header("Platform Variations")]
    public GameObject[] platform_objects;
    public float platform_object_length;
}
