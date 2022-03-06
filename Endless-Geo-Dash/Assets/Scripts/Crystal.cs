/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Crystal class, which contains the
functions that make up a Crystal object
*/
using UnityEngine;

public enum Elements { Fire, Water, Earth}

public class Crystal : MonoBehaviour
{
    private Elements type;

    private SkinnedMeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
    }

    private void Start()
    {
        SetRandomElement();
        SetMaterial();
    }

    // Sets a random element to the crystal
    private void SetRandomElement()
    {
        int random_element = Random.Range(1, 3);
        if (random_element == 1)
        {
            type = Elements.Fire;
        }
        else if (random_element == 2)
        {
            type = Elements.Water;
        }
        else
        {
            type = Elements.Earth;
        }
    }

    // sets the color of the material of a crystal object
    private void SetMaterial()
    {
        if (type == Elements.Fire)
        {
            mesh.materials[0].color = Color.red;
        }
        else if (type == Elements.Water)
        {
            mesh.materials[0].color = Color.blue;
        }
        else
        {
            mesh.materials[0].color = Color.green;
        }
    }

    // returns type
    public Elements GetElementalType()
    {
        return type;
    }

    // Destroy object when player collides
    private void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

}
