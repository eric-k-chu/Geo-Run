/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the ReversalDebuff class, which switches the state of the Reversal Debuff 
animator.
*/
using UnityEngine;

namespace GPEJ.Player
{
    public class ReversalDebuff : MonoBehaviour
    {
        private Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            animator.SetBool("IsDebuffOn", true);
        }

        private void OnDisable()
        {
            animator.SetBool("IsDebuffOn", false);
        }
    }
}
