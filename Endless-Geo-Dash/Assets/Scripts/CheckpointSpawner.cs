/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CheckpointSpawner class, which will spawn new
checkpoints as the player moves forward
*/
using UnityEngine;

public class CheckpointSpawner : MonoBehaviour
{
    [SerializeField] private TerrainObjects terrains;

    private GameObject[] checkpoint;

    private float length;

    private bool is_triggered = true;

    private void Start()
    {
        checkpoint = terrains.checkpoint_objects;
        length = terrains.checkpoint_object_length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (is_triggered)
        {
            Vector3 spawn_position_1 = new Vector3(transform.position.x,
                transform.position.y, transform.position.z + length);

            Quaternion orientation = Quaternion.Euler(Vector3.zero);

            int index = Random.Range(0, checkpoint.Length);
            Instantiate(checkpoint[index], spawn_position_1, orientation);
            CheckpointDisplay.instance.SetCheckpointDisplay(index);

            // prevents double triggers
            is_triggered = false;
        }
    }

    private void OnTriggerExit()
    {
        Destroy(transform.parent.gameObject, 8f);
    }
}
