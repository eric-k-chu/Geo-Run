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
            volume_value = PlayerPrefs.GetFloat(UserPref.instance.MasterVolume);
            SetMasterVolume(volume_value);

        }
        else if (type == VolumeType.Music)
        {
            volume_value = PlayerPrefs.GetFloat(UserPref.instance.MusicVolume);
            SetMusicVolume(volume_value);
        }
        else if (type == VolumeType.SFX)
        {
            volume_value = PlayerPrefs.GetFloat(UserPref.instance.SFXVolume);
            SetSFXVolume(volume_value);
        }
        else if (type == VolumeType.UI)
        {
            volume_value = PlayerPrefs.GetFloat(UserPref.instance.UIVolume);
            SetUIVolume(volume_value);
        }
        ui_slider.value = volume_value;
    }

    // audio mixer value is logarithmic, so conversion is needed float -> log 10

    public void SetMasterVolume(float value)
    {
        PlayerPrefs.SetFloat(UserPref.instance.MasterVolume, value);
        master_mixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(UserPref.instance.MusicVolume, value);
        master_mixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(UserPref.instance.SFXVolume, value);
        master_mixer.SetFloat("SFXVol", Mathf.Log10(value) * 20);
    }

    public void SetUIVolume(float value)
    {
        PlayerPrefs.SetFloat(UserPref.instance.UIVolume, value);
        master_mixer.SetFloat("UIVol", Mathf.Log10(value) * 20);
    }

}
