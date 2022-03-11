/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the OutOfBounds class, which kills the player when
they collide with an OutOfBounds object
*/
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        Debug.Log("Died to out of bounds");
        GameStateManager.instance.TransitionToLostState();   
    }
}
