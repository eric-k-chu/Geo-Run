/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

SUMMARY:
MainMenuCharacterDisplay changes the character object in the Menu-Scene
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
