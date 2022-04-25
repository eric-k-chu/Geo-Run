/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the SetVolumeSlider class, which changes the volume slider and upates the 
volume of the game based on the user's preference.
*/

using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public enum VolumeType { Master, Music, SFX, UI }

    public class SetVolumeSlider : MonoBehaviour
    {
        [SerializeField] private AudioMixer master_mixer;
        [SerializeField] private VolumeType type;

        private Slider ui_slider;

        // audio mixer value is logarithmic, so conversion is needed float -> log 10
        public void SetMasterVolume(float value)
        {
            PlayerPrefs.SetFloat(Preference.MasterVolume, value);
            master_mixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
        }

        public void SetMusicVolume(float value)
        {
            PlayerPrefs.SetFloat(Preference.MusicVolume, value);
            master_mixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
        }

        public void SetSFXVolume(float value)
        {
            PlayerPrefs.SetFloat(Preference.SFXVolume, value);
            master_mixer.SetFloat("SFXVol", Mathf.Log10(value) * 20);
        }

        public void SetUIVolume(float value)
        {
            PlayerPrefs.SetFloat(Preference.UIVolume, value);
            master_mixer.SetFloat("UIVol", Mathf.Log10(value) * 20);
        }

        private void Awake()
        {
            ui_slider = GetComponent<Slider>();
        }

        private void Start()
        {
            float volume_value = 0f;
            if (type == VolumeType.Master)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MasterVolume, 0.5f);
                SetMasterVolume(volume_value);

            }
            else if (type == VolumeType.Music)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MusicVolume, 0.5f);
                SetMusicVolume(volume_value);
            }
            else if (type == VolumeType.SFX)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.SFXVolume, 0.5f);
                SetSFXVolume(volume_value);
            }
            else if (type == VolumeType.UI)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.UIVolume, 0.5f);
                SetUIVolume(volume_value);
            }
            ui_slider.value = volume_value;

            if (SceneManager.GetActiveScene().name == SceneNames.Game)
            {
                master_mixer.SetFloat("LowPassFreq", 1000f);
            }
            else if (SceneManager.GetActiveScene().name == SceneNames.MainMenu)
            {
                master_mixer.SetFloat("LowPassFreq", 5000f);
            }
        }
    }
}
