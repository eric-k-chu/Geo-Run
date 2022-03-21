/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the SetVolumeNumber class, which contains functions
that updates the Volume number based on the user's preferences
*/
using UnityEngine;
using UnityEngine.UI;

namespace GPEJ.UI
{
    public class SetVolumeNumber : MonoBehaviour
    {
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

        private void UpdateVolumeText()
        {
            float volume_value = 0;
            if (type == VolumeType.Master)
            {
                volume_value = PlayerPrefs.GetFloat(UserPref.instance.MasterVolume);
            }
            else if (type == VolumeType.Music)
            {
                volume_value = PlayerPrefs.GetFloat(UserPref.instance.MusicVolume);
            }
            else if (type == VolumeType.SFX)
            {
                volume_value = PlayerPrefs.GetFloat(UserPref.instance.SFXVolume);
            }
            else if (type == VolumeType.UI)
            {
                volume_value = PlayerPrefs.GetFloat(UserPref.instance.UIVolume);
            }
            int volume_to_change = (int)(volume_value * 100f);
            ui_text.text = volume_to_change.ToString();
        }
    }
}
