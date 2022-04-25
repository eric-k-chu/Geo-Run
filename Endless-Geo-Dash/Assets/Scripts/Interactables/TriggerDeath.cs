/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the TriggerDeath class, which causes the player to die if they collide 
with the trigger death colliders
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
