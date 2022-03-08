/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the Checkpoints class, which holds a variable that
indicates the elemental type of a checkpoint
*/
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] private Elements elemental_type;

    public void SetElementalType(Elements type)
    {
        elemental_type = type;    
    }

    public Elements GetElementalType()
    {
        return elemental_type;
    }
}
