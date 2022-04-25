/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the DisplayUIMenu class, which contains functions animate the different 
UI menus.
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class DisplayUIMenu : MonoBehaviour
    {
        private Animator ui_animator;

        public void ShowUI()
        {
            ui_animator.SetTrigger("Active");
        }

        public void HideUI()
        {
            ui_animator.SetTrigger("Inactive");
        }

        private void Awake()
        {
            ui_animator = GetComponent<Animator>();
        }
    }
}
