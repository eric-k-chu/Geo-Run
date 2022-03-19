/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the TriggerDeath class, which causes 
the player to die if the collide with a trigger layer
*/
using UnityEngine;

public class TriggerDeath : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        AudioManager.instance.PlayDeathSFX();

        if (!GameStateManager.instance.IsLost())
        {
            GameStateManager.instance.LoseGame();
        }
    }
}
