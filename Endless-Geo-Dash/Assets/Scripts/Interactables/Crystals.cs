/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Crystals class, which are collectibles
that increase the score multiplier
*/
using UnityEngine;

namespace GPEJ.Player.Collectibles
{
    public class Crystals : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

            }
        }
    }
}
