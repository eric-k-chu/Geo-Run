/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CharacterSelect class, which tells the CharacterHighlight
object which character image should be highlighted
*/
using UnityEngine;

namespace GPEJ.UI
{
    public class CharacterSelect : MonoBehaviour
    {
        [SerializeField] private GameObject[] ui_character_image_list;

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
                    PlayerPrefs.SetInt(UserPref.instance.CharacterType, id);
                }
            }
        }
    }
}
