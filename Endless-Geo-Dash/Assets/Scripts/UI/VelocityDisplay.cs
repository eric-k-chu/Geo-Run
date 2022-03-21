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
        private Text velocity;

        private void Awake()
        {
            velocity = GetComponent<Text>();
        }

        private void Start()
        {
            GameStateManager.instance.OnPlayerVelocityIncrease += UpdateVelocityText;
        }

        private void UpdateVelocityText(float velocity_value)
        {
            velocity.text = ((int)(velocity_value)).ToString() + " m/s";
        }

        private void OnDestroy()
        {
            GameStateManager.instance.OnPlayerVelocityIncrease -= UpdateVelocityText;
        }
    }
}
