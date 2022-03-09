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

public class CharacterHighlight : MonoBehaviour
{
    [SerializeField] private int character_type;

    [SerializeField] private Color selected_color;

    [SerializeField] private Color disabled_color;

    private Image ui_image;

    private void Awake()
    {
        ui_image = GetComponent<Image>();
    }

    private void Start()
    {
        if (character_type == PlayerPrefs.GetInt(UserPref.instance.CharacterType))
        {
            ui_image.color = selected_color;
        }
        else
        {
            ui_image.color = disabled_color;
        }
    }

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
}
