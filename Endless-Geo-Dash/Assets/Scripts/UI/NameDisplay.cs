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
    [SerializeField] private PlayerVariables player_var;

    private Text ui_text;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        ui_text.text = player_var.GetName();
    }

}
