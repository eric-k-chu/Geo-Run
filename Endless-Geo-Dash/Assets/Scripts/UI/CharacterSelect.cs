/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the CharacterSelect class, which tells the CharacterHighlight
class which character image should be highlighted.
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class CharacterSelect : MonoBehaviour
    {
        [SerializeField] private GameObject[] ui_character_image_list;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                PlayerPrefs.SetInt(Preference.CharacterType, 0);
            }
        }

        public void ChangeCharacter(int id)
        {
            // Turn off previous highlighted image and higlight the player selected image
            for (int index = 0; index < ui_character_image_list.Length; index++)
            {
                CharacterHighlight character_button = ui_character_image_list[index].GetComponent<CharacterHighlight>();
                if (id != index)
                {
                    if (ui_character_image_list[index].activeSelf)
                    {
                        character_button.HighlightIMG(false);
                    }
                }
                else
                {
                    character_button.HighlightIMG(true);
                    PlayerPrefs.SetInt(Preference.CharacterType, id);
                    PlayerPrefs.Save();
                }
            }
        }
    }
}
