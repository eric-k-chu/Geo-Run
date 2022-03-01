/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the BackgroundSpawner class, which will spawn new background objects as the player moves forward
*/
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject background_model;

    [SerializeField] private float background_model_length;

    private bool is_triggered = true;

    private void OnTriggerEnter()
    {
        if (is_triggered)
        {
            Vector3 spawn_position_1 = new Vector3(transform.position.x, transform.position.y, transform.position.z + background_model_length);
            Vector3 spawn_position_2 = new Vector3(transform.position.x, transform.position.y, transform.position.z + (2 * background_model_length));
            Quaternion orientation = Quaternion.Euler(Vector3.zero);

            Instantiate(background_model, spawn_position_1, orientation);
            Instantiate(background_model, spawn_position_2, orientation);

            is_triggered = false;   // prevents double triggers
        }
    }

    private void OnTriggerExit()
    {
        Destroy(transform.parent.gameObject, 5f);    
    }
}
