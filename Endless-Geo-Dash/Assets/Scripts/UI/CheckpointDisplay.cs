/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CheckpointDisplay class, which will display 
the next checkpoint type on the screen
*/
using UnityEngine;
using UnityEngine.UI;

public class CheckpointDisplay : MonoBehaviour
{
    private string fire_string = "Fire";
    private string water_string = "Water";
    private string earth_string = "Earth";

    private Text ui_text;

    [SerializeField] private Color fire_color;
    [SerializeField] private Color water_color;
    [SerializeField] private Color earth_color;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        GameStateManager.instance.OnPlayerCheckpoint += SetCheckpointDisplay;
    }

    // Displays the next checkpoint type given an integer param
    // 1 for fire, 2 for water, 3 for earth
    public void SetCheckpointDisplay(int val)
    {
        if (val == 1)
        {
            ui_text.color = fire_color;
            ui_text.text = fire_string;
        }
        else if (val == 2)
        {
            ui_text.color = water_color;
            ui_text.text = water_string;
        }
        else if (val == 3)
        {
            ui_text.color = earth_color;
            ui_text.text = earth_string;
        }
    }

    private void OnDestroy()
    {
        GameStateManager.instance.OnPlayerCheckpoint -= SetCheckpointDisplay;
    }
}
