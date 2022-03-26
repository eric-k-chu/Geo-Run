/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the VelocityDisplay class, which display
the player's current velocity
*/
using UnityEngine;
using UnityEngine.UI;

namespace GPEJ
{
    public class VelocityDisplay : MonoBehaviour
    {
        [SerializeField] private RuntimeDataContainer runtime_data;

        private Text velocity;

        private void Awake()
        {
            velocity = GetComponent<Text>();
        }

        private void LateUpdate()
        {
            if (Time.timeScale != 0f)
            {
                velocity.text = ((int)runtime_data.velocity).ToString() + " m/s";
            }
        }
    }
}
