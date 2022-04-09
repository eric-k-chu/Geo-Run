/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

SUMMARY:
This class is reponsible for switching between the animation state of the Debuff Reversal
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
