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

public enum VolumeType { Master, Music, SFX, UI }

public class SetVolumeNumber : MonoBehaviour
{
    [SerializeField] private GameSettings game_settings;

    [SerializeField] private VolumeType type;

    private Text ui_text;

    private void Awake()
    {
        ui_text = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateVolumeText();       
    }

    private void Update()
    {
        UpdateVolumeText();
    }

    // Changes the volume text given user_settings.volume
    private void UpdateVolumeText()
    {
        float volume_value = 0;
        if (type == VolumeType.Master)
        {
            volume_value = game_settings.master_volume;
        }
        else if (type == VolumeType.Music)
        {
            volume_value = game_settings.music_volume;
        }
        else if (type == VolumeType.SFX)
        {
            volume_value = game_settings.sfx_volume;
        }
        else if (type == VolumeType.UI)
        {
            volume_value = game_settings.ui_volume;
        }
        int volume_to_change = (int)(volume_value * 100f);
        ui_text.text = volume_to_change.ToString();
    }
}
