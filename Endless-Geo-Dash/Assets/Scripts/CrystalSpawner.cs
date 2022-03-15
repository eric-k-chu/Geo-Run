/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the CrystalSpawner class, which chooses
the elemental type of a crystal for a platform
*/
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] private Crystal[] crystals;

    private int[] elemental_typeset_0 = { 0, 1, 2 };
    private int[] elemental_typeset_1 = { 0, 2, 1 };
    private int[] elemental_typeset_2 = { 1, 0, 2 };
    private int[] elemental_typeset_3 = { 1, 2, 0 };
    private int[] elemental_typeset_4 = { 2, 1, 0 };
    private int[] elemental_typeset_5 = { 2, 0, 1 };

    private void Start()
    {
        int random_permutation = Random.Range(0, 5);

        switch (random_permutation)
        {
            case 0:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_0[i]);
                }
                break;
            case 1:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_1[i]);
                }
                break;
            case 2:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_2[i]);
                }
                break;
            case 3:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_3[i]);
                }
                break;
            case 4:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_4[i]);
                }
                break;
            case 5:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_5[i]);
                }
                break;
            default:
                for (int i = 0; i < crystals.Length; i++)
                {
                    crystals[i].SetElementalType(elemental_typeset_0[i]);
                }
                break;
        }

    }

}
