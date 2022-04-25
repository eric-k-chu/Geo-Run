/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the ButtonSFX class, which plays the UI button sfx.
*/

using UnityEngine;

namespace GPEJ.UI
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
