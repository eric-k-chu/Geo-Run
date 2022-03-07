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
    [SerializeField] private GameObject[] ui_character_list;

    [SerializeField] private UserSettings user_settings;

    public void ChangeCharacter(int id)
    {
        for (int index = 0; index < ui_character_list.Length; index++)
        {
            if (id != index)
            {
                if (ui_character_list[index].activeSelf)
                {
                    ui_character_list[index].GetComponent<CharacterHighlight>().HighlightIMG(false);
                }
            }
            else
            {
                ui_character_list[index].GetComponent<CharacterHighlight>().HighlightIMG(true);
                user_settings.character_type = id;
            }
        }
    }
}
