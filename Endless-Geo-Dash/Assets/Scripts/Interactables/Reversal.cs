/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

Summary:
This file contains the Reversal class, which swaps
the directional movement keys of the PlayerController class on
collision.
*/
using UnityEngine;

namespace GPEJ.Player.Interactables
{
    public class Reversal : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            other.GetComponent<PlayerController>().SwapKeys(true); 
        }
    }
}
