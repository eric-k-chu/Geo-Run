/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CrystalType class, contains methods
that set the elemental type of a crystal and return the elemental type
*/
using UnityEngine;

public class CrystalType : MonoBehaviour
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

    public void SetElementalType(int ele_type)
    {
        if (ele_type == 0)
        {
            type = Elements.Fire;
            mesh.material = fire_mat;
        }
        else if (ele_type == 1)
        {
            type = Elements.Water;
            mesh.material = water_mat;
        }
        else if (ele_type == 2)
        {
            type = Elements.Earth;
            mesh.material = earth_mat;
        }
    }

    public Elements GetElementalType()
    {
        return type;
    }

    // Destroy crystal when player collides
    private void OnTriggerEnter()
    {
        AudioManager.instance.PlayCrystalPickupSFX();
        Destroy(gameObject);
    }

}
