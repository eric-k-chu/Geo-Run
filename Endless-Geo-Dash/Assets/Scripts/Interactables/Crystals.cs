/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the Crystals class, which are items that increase the score multiplier
*/

using UnityEngine;

namespace GPEJ.Player.Interactables
{
    public class Crystals : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel crystal_channel;

        private void OnTriggerEnter(Collider other)
        {
            if (other == null) return;

            AudioManager.instance.PlayCrystalPickupSFX();
            crystal_channel.RaiseEvent();
            gameObject.SetActive(false);
        }
    }
}
