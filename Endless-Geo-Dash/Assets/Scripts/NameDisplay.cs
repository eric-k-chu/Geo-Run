/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the NameDisplay class, which displays the name of the 
character that the user chooses.
*/
using UnityEngine;
using UnityEngine.UI;

public class NameDisplay : MonoBehaviour
{
    [SerializeField] private UserSettings user_settings;

    private Text ui_text;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        switch (user_settings.character_type)
        {
            case 0:
                ui_text.text = "Cube";
                break;
            case 1:
                ui_text.text = "Pyramid";
                break;
            default:
                break;
        }
    }

}
