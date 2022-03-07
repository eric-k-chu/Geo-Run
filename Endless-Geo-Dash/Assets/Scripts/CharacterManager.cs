/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CharacterManager class, which manages
which character is highlighted in the CharacterHighlight Selection GUI
*/
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ui_character_image_list;

    [SerializeField] private GameSettings game_settings;

    public void ChangeCharacter(int id)
    {
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
                game_settings.character_type = id;
            }
        }
    }
}
