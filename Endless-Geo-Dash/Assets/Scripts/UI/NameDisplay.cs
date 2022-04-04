/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the NameDisplay class, which displays the name of the 
character that the user chooses.
*/
using UnityEngine;
using TMPro;

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
