/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the VelocityDisplay class, which displays the player's current velocity.
*/

using TMPro;
using UnityEngine;

namespace GPEJ
{
    public class VelocityDisplay : MonoBehaviour
    {
        [SerializeField] private RuntimeDataContainer runtime_data;

        private TextMeshProUGUI text_mesh;

        private void Awake()
        {
            text_mesh = GetComponent<TextMeshProUGUI>();
        }

        private void LateUpdate()
        {
            if (Time.timeScale != 0f)
            {
                text_mesh.text = ((int)runtime_data.velocity).ToString() + " m/s";
            }
        }
    }
}
