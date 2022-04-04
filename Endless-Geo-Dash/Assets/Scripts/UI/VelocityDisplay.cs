/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the VelocityDisplay class, which display
the player's current velocity
*/
using UnityEngine;
using TMPro;

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
