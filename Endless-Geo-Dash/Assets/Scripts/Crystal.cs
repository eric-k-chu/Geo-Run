/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Crystal class, which contains the
functions that make up a Crystal object
*/
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private Elements type;

    private Renderer mesh;

    [SerializeField] private Material fire_mat;
    [SerializeField] private Material water_mat;
    [SerializeField] private Material earth_mat;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        SetRandomElement();
        SetMaterial();
    }

    // Sets a random element to the crystal
    private void SetRandomElement()
    {
        int random_element = Random.Range(1, 4);
        if (random_element == 1)
        {
            type = Elements.Fire;
        }
        else if (random_element == 2)
        {
            type = Elements.Water;
        }
        else if (random_element == 3)
        {
            type = Elements.Earth;
        }
    }

    // sets the color of the material of a crystal object
    private void SetMaterial()
    {
        if (type == Elements.Fire)
        {
            mesh.material = fire_mat;
        }
        else if (type == Elements.Water)
        {
            mesh.material = water_mat;
        }
        else if (type == Elements.Earth)
        {
            mesh.material = earth_mat;
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
        AudioManager.instance.PlayCrystalPickupSFX();
        Destroy(gameObject);
    }

}
