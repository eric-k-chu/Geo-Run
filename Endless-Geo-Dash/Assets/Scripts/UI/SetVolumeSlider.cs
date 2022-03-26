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

        private const string k_master_vol = "Master-Volume";
        private const string k_music_vol = "Music-Volume";
        private const string k_sfx_vol = "SFX-Volume";
        private const string k_ui_vol = "UI-Volume";
        private Slider ui_slider;

        // audio mixer value is logarithmic, so conversion is needed float -> log 10
        public void SetMasterVolume(float value)
        {
            PlayerPrefs.SetFloat(k_master_vol, value);
            master_mixer.SetFloat("MasterVol", Mathf.Log10(value) * 20);
        }

        public void SetMusicVolume(float value)
        {
            PlayerPrefs.SetFloat(k_music_vol, value);
            master_mixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
        }

        public void SetSFXVolume(float value)
        {
            PlayerPrefs.SetFloat(k_sfx_vol, value);
            master_mixer.SetFloat("SFXVol", Mathf.Log10(value) * 20);
        }

        public void SetUIVolume(float value)
        {
            PlayerPrefs.SetFloat(k_ui_vol, value);
            master_mixer.SetFloat("UIVol", Mathf.Log10(value) * 20);
        }

        private void Awake()
        {
            ui_slider = GetComponent<Slider>();

            if (!PlayerPrefs.HasKey(k_master_vol))
            {
                PlayerPrefs.SetFloat(k_master_vol, 0.25f);
            }

            if (!PlayerPrefs.HasKey(k_music_vol))
            {
                PlayerPrefs.SetFloat(k_music_vol, 0.25f);
            }

            if (!PlayerPrefs.HasKey(k_sfx_vol))
            {
                PlayerPrefs.SetFloat(k_sfx_vol, 0.25f);
            }

            if (!PlayerPrefs.HasKey(k_ui_vol))
            {
                PlayerPrefs.SetFloat(k_ui_vol, 0.25f);
            }
        }

        private void Start()
        {
            float volume_value = 0f;
            if (type == VolumeType.Master)
            {
                volume_value = PlayerPrefs.GetFloat(k_master_vol);
                SetMasterVolume(volume_value);

            }
            else if (type == VolumeType.Music)
            {
                volume_value = PlayerPrefs.GetFloat(k_music_vol);
                SetMusicVolume(volume_value);
            }
            else if (type == VolumeType.SFX)
            {
                volume_value = PlayerPrefs.GetFloat(k_sfx_vol);
                SetSFXVolume(volume_value);
            }
            else if (type == VolumeType.UI)
            {
                volume_value = PlayerPrefs.GetFloat(k_ui_vol);
                SetUIVolume(volume_value);
            }
            ui_slider.value = volume_value;
        }
    }
}
