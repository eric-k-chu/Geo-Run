/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the NameDisplay class, which displays the name of the character that the 
user chooses.
*/

using TMPro;
using UnityEngine;

namespace GPEJ.UI
{
    public class NameDisplay : MonoBehaviour
    {
        [SerializeField] private PlayerVariables player_var;

        private TextMeshProUGUI text_mesh;

        private void Awake()
        {
            text_mesh = GetComponent<TextMeshProUGUI>();
        }

        private void Start()
        {
            text_mesh.text = player_var.GetName();
        }
    }
}
