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
    [SerializeField] private UserSettings user_settings;

    [SerializeField] private AudioMixer master_mixer;

    private Slider ui_slider;

    private void Awake()
    {
        ui_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        ui_slider.value = user_settings.volume;
    }

    // Change the volume of the game. Slider will call this function
    public void SetVolume(float value)
    {
        user_settings.volume = value;
        /* TODO:
         * Add AudioMixer and set change the settings based on param 'value'
         * 
         * CONVERSION FACTOR:
         * master_mixer.SetFloat(arg, Mathf.Log10(value) * 20);
         * 
         */

    }
}
