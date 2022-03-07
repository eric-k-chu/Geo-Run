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

public class CharacterPortraitDisplay : MonoBehaviour
{
    [SerializeField] private UserSettings user_settings;

    [SerializeField] private Sprite[] character_image_list;

    private Image ui_image;

    private void Awake()
    {
        ui_image = GetComponent<Image>();
    }

    private void Start()
    {
        ui_image.sprite = character_image_list[user_settings.character_type];
    }
}
