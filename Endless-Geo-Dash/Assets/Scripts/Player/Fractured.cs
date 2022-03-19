/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Fractured class, which applies a force at a random 
direction to objects that contain the Fractured component.
*/
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Fractured : MonoBehaviour
{
    private Rigidbody obj_rigidbody;

    private void Awake()
    {
        obj_rigidbody = GetComponent<Rigidbody>(); 
    }

    private void Start()
    {
        float x = Random.Range(-360f, 360f);
        float y = Random.Range(-360f, 360f);
        float z = Random.Range(-360f, 360f);
        Vector3 force_vector = new Vector3(x, y, z);
        obj_rigidbody.AddForce(force_vector, ForceMode.Impulse);
    }
}
