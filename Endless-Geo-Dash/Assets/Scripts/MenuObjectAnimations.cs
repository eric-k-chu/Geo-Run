/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the MenuObjectAnimations class, which contains
functions that rotate the background objects
*/
using UnityEngine;

public class MenuObjectAnimations : MonoBehaviour
{
    [SerializeField] private float rotation_speed;

    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotation_speed) * Time.deltaTime);
    }
}
