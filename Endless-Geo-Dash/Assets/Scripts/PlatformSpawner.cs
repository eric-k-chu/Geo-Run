/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PlatformSpawner class, which will spawn new platforms when the player has 
left the previous platform.
*/

using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] lanes;

    [SerializeField] private float lane_length;

    private bool is_triggered = true;

    private void OnTriggerEnter()
    {
        if (is_triggered)
        {
            Vector3 spawn_point_1 = new Vector3(transform.position.x, 
                transform.position.y, transform.position.z + lane_length);

            Quaternion orientation = Quaternion.Euler(Vector3.zero);
            int lane_index = Random.Range(0, 5);
            Instantiate(lanes[lane_index], spawn_point_1, orientation);

            // prevents double triggers
            is_triggered = false; 
        }
    }

    private void OnTriggerExit()
    {
        Destroy(transform.parent.gameObject, 2f);    
    }
}
