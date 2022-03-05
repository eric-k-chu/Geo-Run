/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SetVolumeNumber class, which contains functions
that allow update the Volume number based on the user's preferences
*/
using UnityEngine;
using UnityEngine.UI;

public class SetVolumeNumber : MonoBehaviour
{
    [SerializeField] private UserSettings user_settings;

    private Text ui_text;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateVolumeText();       
    }

    private void LateUpdate()
    {
        UpdateVolumeText();
    }

    // Changes the volume text given user_settings.volume
    private void UpdateVolumeText()
    {
        int vol = (int)user_settings.volume;
        ui_text.text = vol.ToString();
    }
}
