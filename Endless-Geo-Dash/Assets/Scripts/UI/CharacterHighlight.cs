/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the CharacterHighlight class, which highlights the character portrait 
based on user preference in the settings menu.
*/

using UnityEngine;
using UnityEngine.UI;

namespace GPEJ.UI
{
    public class CharacterHighlight : MonoBehaviour
    {
        [SerializeField] private int character_type;
        [SerializeField] private Color selected_color;
        [SerializeField] private Color disabled_color;

        private Image ui_image;
      
        public void HighlightIMG(bool val)
        {
            if (val)
            {
                ui_image.color = selected_color;
            }
            else
            {
                ui_image.color = disabled_color;
            }
        }

        private void Awake()
        {
            ui_image = GetComponent<Image>();
            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                PlayerPrefs.SetInt(Preference.CharacterType, 0);
            }
        }

        private void Start()
        {
            if (character_type == PlayerPrefs.GetInt(Preference.CharacterType))
            {
                ui_image.color = selected_color;
            }
            else
            {
                ui_image.color = disabled_color;
            }
        }
    }
}
