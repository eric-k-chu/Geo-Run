/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the PooledObjectManager class, which manages
all the object pools in the game
*/
using System;
using System.Collections.Generic;
using UnityEngine;

public enum TerrainType
{
    Background,
    Platform,
    Checkpoint
}

[Serializable]
public class PooledObjects
{
    public int amount;
    public GameObject obj;
    [HideInInspector] public List<GameObject> object_list;
}

public class PooledObjectManager : MonoBehaviour
{
    public static PooledObjectManager instance { get; private set; }

    public List<PooledObjects> pooled_object_list = new List<PooledObjects>();

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < pooled_object_list.Count; i++)
        {
            for (int j = 0; j < pooled_object_list[i].amount; j++)
            {
                GameObject pooled_obj = Instantiate(pooled_object_list[i].obj);
                pooled_obj.SetActive(false);
                pooled_object_list[i].object_list.Add(pooled_obj);
            }
        }
    }

    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < pooled_object_list[index].object_list.Count; i++)
        {
            if (!pooled_object_list[index].object_list[i].activeInHierarchy)
            {
                return pooled_object_list[index].object_list[i];
            }
        }
        return null;
    }


}
