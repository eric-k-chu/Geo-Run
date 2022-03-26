/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the DisplayUIMenu class, which contains
functions animate the different UI menus
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
