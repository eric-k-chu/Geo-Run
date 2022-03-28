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

            if (!PlayerPrefs.HasKey(Preference.MasterVolume))
            {
                PlayerPrefs.SetFloat(Preference.MasterVolume, 0.25f);
            }

            if (!PlayerPrefs.HasKey(Preference.MusicVolume))
            {
                PlayerPrefs.SetFloat(Preference.MusicVolume, 0.25f);
            }

            if (!PlayerPrefs.HasKey(Preference.SFXVolume))
            {
                PlayerPrefs.SetFloat(Preference.SFXVolume, 0.25f);
            }

            if (!PlayerPrefs.HasKey(Preference.UIVolume))
            {
                PlayerPrefs.SetFloat(Preference.UIVolume, 0.25f);
            }
        }

        private void Start()
        {
            float volume_value = 0f;
            if (type == VolumeType.Master)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MasterVolume);
                SetMasterVolume(volume_value);

            }
            else if (type == VolumeType.Music)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MusicVolume);
                SetMusicVolume(volume_value);
            }
            else if (type == VolumeType.SFX)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.SFXVolume);
                SetSFXVolume(volume_value);
            }
            else if (type == VolumeType.UI)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.UIVolume);
                SetUIVolume(volume_value);
            }
            ui_slider.value = volume_value;
        }
    }
}
