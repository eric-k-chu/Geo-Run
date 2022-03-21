/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the ButtonSFX class, which plays the
UI button sfx on state enter
*/
using UnityEngine;

namespace GPEJ.Sounds
{
    public class ButtonSFX : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (stateInfo.IsName("Pressed"))
            {
                AudioManager.instance.PlayUIButton();
            }
        }
    }
}
