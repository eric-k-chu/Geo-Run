/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CharacterHighlight class, which highlights the
character portrait based on user preference
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

        private const string k_character_type = "CharacterInfo-Type";
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
            if (!PlayerPrefs.HasKey(k_character_type))
            {
                PlayerPrefs.SetInt(k_character_type, 0);
            }
        }

        private void Start()
        {
            if (character_type == PlayerPrefs.GetInt(k_character_type))
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
