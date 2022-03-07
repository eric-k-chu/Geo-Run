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
    [SerializeField] private GameSettings game_settings;

    private Image ui_image;

    private void Awake()
    {
        ui_image = GetComponent<Image>();
    }

    private void Start()
    {
        ui_image.sprite = game_settings.GetPortrait();
    }
}
