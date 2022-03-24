/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the AudioManager class, which controls
the given audio sources in the game
*/
using UnityEngine;

namespace GPEJ
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance { get; private set; }

        [Header("Audio Sources")]
        [SerializeField] private AudioSource music_source;
        [SerializeField] private AudioSource sfx_source;
        [SerializeField] private AudioSource ui_source;

        [Header("Audio Clips")]
        [SerializeField] private AudioClip jump;
        [SerializeField] private AudioClip move_sideways;
        [SerializeField] private AudioClip ui_button;
        [SerializeField] private AudioClip ui_menu_appear;
        [SerializeField] private AudioClip crystal_pickup;
        [SerializeField] private AudioClip death;

        private void Awake()
        {
            instance = this;
        }

        public void PlayJumpSFX()
        {
            sfx_source.PlayOneShot(jump);
        }

        public void PlayMoveSFX()
        {
            sfx_source.PlayOneShot(move_sideways);
        }

        public void PlayUIButton()
        {
            ui_source.PlayOneShot(ui_button);
        }

        public void PlayUIMenuAppear()
        {
            ui_source.PlayOneShot(ui_menu_appear);
        }

        public void PlayCrystalPickupSFX()
        {
            sfx_source.PlayOneShot(crystal_pickup);
        }

        public void PlayDeathSFX()
        {
            sfx_source.PlayOneShot(death);
        }

        public void PlayMusic()
        {
            music_source.Play();
        }

        public void PauseMusic()
        {
            music_source.Pause();
        }

        public void ResumeMusic()
        {
            music_source.UnPause();
        }
    }
}
