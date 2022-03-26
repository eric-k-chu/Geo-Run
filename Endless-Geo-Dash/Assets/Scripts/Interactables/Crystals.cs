/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Crystals class, which are collectibles
that increase the score multiplier
*/
using UnityEngine;

namespace GPEJ.Player.Interactables
{
    public class Crystals : MonoBehaviour
    {
        [SerializeField] private VoidEventChannel crystal_channel;

        private void OnTriggerEnter(Collider other)
        {
            AudioManager.instance.PlayCrystalPickupSFX();
            crystal_channel.RaiseEvent();
            gameObject.SetActive(false);
        }
    }
}
