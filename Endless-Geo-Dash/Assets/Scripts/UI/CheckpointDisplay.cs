/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CheckpointDisplay class, which will display 
the element of the next checkpoint on the screen
*/
using UnityEngine;
using UnityEngine.UI;

public class CheckpointDisplay : MonoBehaviour
{
    public static CheckpointDisplay instance { get; private set; }

    private string fire_string = "Fire";
    private string water_string = "Water";
    private string earth_string = "Earth";

    private Text ui_text;

    [SerializeField] private Color fire_color;
    [SerializeField] private Color water_color;
    [SerializeField] private Color earth_color;

    private void Awake()
    {
        instance = this;
        ui_text = GetComponent<Text>();
    }

    // Updates the next checkpoint given an integer param
    // 0 for fire, 1 for water, 2 for earth
    public void SetCheckpointDisplay(int val)
    {
        if (val == 0)
        {
            ui_text.color = fire_color;
            ui_text.text = fire_string;
        }
        else if (val == 1)
        {
            ui_text.color = water_color;
            ui_text.text = water_string;
        }
        else if (val == 2)
        {
            ui_text.color = earth_color;
            ui_text.text = earth_string;
        }
    }
}
