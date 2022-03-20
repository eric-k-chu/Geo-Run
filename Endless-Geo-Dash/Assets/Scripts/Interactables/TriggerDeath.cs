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
        if (other.gameObject.CompareTag("Player Collision Area"))
        {
            AudioManager.instance.PlayDeathSFX();
            GameStateManager.instance.SetFinalDistanceTraveled((int)other.gameObject.transform.parent.transform.position.z);
            if (!GameStateManager.instance.IsLost())
            {
                GameStateManager.instance.LoseGame();
            }
        }
    }
}
