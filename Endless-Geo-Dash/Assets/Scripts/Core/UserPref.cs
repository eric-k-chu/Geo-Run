/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the UserPref class, which contains the users
preferences for volume and character type
*/
using UnityEngine;

namespace GPEJ
{
    public enum VolumeType { Master, Music, SFX, UI }

    public class UserPref : MonoBehaviour
    {
        public static UserPref instance { get; private set; }

        private const string k_character_type = "CharacterInfo-Type";
        private const string k_master_vol = "Master-Volume";
        private const string k_music_vol = "Music-Volume";
        private const string k_sfx_vol = "SFX-Volume";
        private const string k_ui_vol = "UI-Volume";
        private const string k_high_score = "High-Score";

        private void Awake()
        {
            instance = this;
            if (!PlayerPrefs.HasKey(k_character_type))
            {
                PlayerPrefs.SetInt(k_character_type, 0);
            }

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

            if (!PlayerPrefs.HasKey(k_high_score))
            {
                PlayerPrefs.SetFloat(k_high_score, 0f);
            }
        }

        public string CharacterType { get { return k_character_type; } }

        public string MasterVolume { get { return k_master_vol; } }

        public string MusicVolume { get { return k_music_vol; } }

        public string SFXVolume { get { return k_sfx_vol; } }

        public string UIVolume { get { return k_ui_vol; } }

        public string HighScore { get { return k_high_score; } }
    }
}
