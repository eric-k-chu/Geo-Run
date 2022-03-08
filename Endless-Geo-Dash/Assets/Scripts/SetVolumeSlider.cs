/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SetVolumeSlider class, which contains functions
that allow the user to interact with the volume slider GUI
*/
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolumeSlider : MonoBehaviour
{
    [SerializeField] private GameSettings game_settings;

    [SerializeField] private AudioMixer master_mixer;

    [SerializeField] private VolumeType type;

    private Slider ui_slider;

    private void Awake()
    {
        ui_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        float volume_value = 0f;
        if (type == VolumeType.Master)
        {
            volume_value = game_settings.master_volume;
            SetMasterVolume(volume_value);
        }
        else if (type == VolumeType.Music)
        {
            volume_value = game_settings.music_volume;
            SetMusicVolume(volume_value);
        }
        else if (type == VolumeType.SFX)
        {
            volume_value = game_settings.sfx_volume;
            SetSFXVolume(volume_value);
        }
        else if (type == VolumeType.UI)
        {
            volume_value = game_settings.ui_volume;
            SetUIVolume(volume_value);
        }
        ui_slider.value = volume_value;
    }

    // Change Master Volume
    public void SetMasterVolume(float value)
    {
        game_settings.master_volume = value;
        master_mixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
    }

    // Change Music Volume
    public void SetMusicVolume(float value)
    {
        game_settings.music_volume = value;
        master_mixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
    }

    // Change SFX Volume
    public void SetSFXVolume(float value)
    {
        game_settings.sfx_volume = value;
        master_mixer.SetFloat("SFXVol", Mathf.Log10(value) * 20);
    }

    // Change UI Volume
    public void SetUIVolume(float value)
    {
        game_settings.ui_volume = value;
        master_mixer.SetFloat("UIVol", Mathf.Log10(value) * 20);
    }

}
