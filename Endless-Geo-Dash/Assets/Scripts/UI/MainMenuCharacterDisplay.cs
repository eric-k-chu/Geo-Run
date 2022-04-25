/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the MainMenuCharacterDisplay, which displays the character that the player
chooses in the main menu.
*/

using UnityEngine;

namespace GPEJ.UI
{
    public class MainMenuCharacterDisplay : MonoBehaviour
    {
        [SerializeField] private GameObject[] characters;

        private void Awake()
        {
            if (!PlayerPrefs.HasKey(Preference.CharacterType))
            {
                PlayerPrefs.SetInt(Preference.CharacterType, 0);
            }
        }

        private void Start()
        {
            characters[PlayerPrefs.GetInt(Preference.CharacterType)].SetActive(true);
        }

        public void UpdateCharacter(int id)
        {
            // Make the selected character visible and disable the rest
            for (int i = 0; i < characters.Length; i++)
            {
                if (id != i)
                {
                    if (characters[i].activeInHierarchy)
                    {
                        characters[i].SetActive(false);
                    } 
                }
                else if (id == i)
                {
                    if (!characters[i].activeInHierarchy)
                    {
                        characters[i].SetActive(true);
                    }
                }
            }
        }
    }
}
