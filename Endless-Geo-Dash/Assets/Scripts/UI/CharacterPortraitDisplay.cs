/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CharacterPortraitDisplay class, which displays the 
portrait of the character the user chooses
*/
using UnityEngine;
using UnityEngine.UI;

namespace GPEJ.UI
{
    public class CharacterPortraitDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerVariables player_var;

        private RawImage ui_image;

        private void Awake()
        {
            ui_image = GetComponent<RawImage>();
        }

        private void Start()
        {
            ui_image.texture = player_var.GetPortrait();
        }
    }
}
