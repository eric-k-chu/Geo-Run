/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the SetVolumeNumber class, which updates the volume text next to the 
volume slider.
*/

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GPEJ.UI
{
    public class SetVolumeNumber : MonoBehaviour
    {
        [SerializeField] private VolumeType type;

        private TextMeshProUGUI text_mesh;
        private bool is_menu = false;

        private void Awake()
        {
            text_mesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            if (SceneManager.GetActiveScene().name == SceneNames.MainMenu)
            {
                is_menu = true;
            }
            UpdateVolumeText();
        }

        private void LateUpdate()
        {
            if (is_menu || Time.timeScale == 0f)
            {
                UpdateVolumeText();
            }
        }

        private void UpdateVolumeText()
        {
            float volume_value = 0;
            if (type == VolumeType.Master)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MasterVolume, 0.5f);
            }
            else if (type == VolumeType.Music)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.MusicVolume, 0.5f);
            }
            else if (type == VolumeType.SFX)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.SFXVolume, 0.5f);
            }
            else if (type == VolumeType.UI)
            {
                volume_value = PlayerPrefs.GetFloat(Preference.UIVolume, 0.5f);
            }
            int volume_to_change = (int)(volume_value * 100f);
            text_mesh.text = volume_to_change.ToString();
        }
    }
}
