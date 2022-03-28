/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the TriggerDeath class, which causes 
the player to die if they collide with the trigger death layer
*/
using UnityEngine;

namespace GPEJ.Player.Interactables
{
    public class TriggerDeath : MonoBehaviour
    {
        [SerializeField] private BoolEventChannel player_death_channel;

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            AudioManager.instance.PlayDeathSFX();
            player_death_channel.RaiseEvent(true);
            gameObject.SetActive(false);
        }
    }
}
