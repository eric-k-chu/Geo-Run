/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

Summary:
This file contains the TerrainManager class, which manages
all the terrain pools in the game
*/
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GPEJ.Terrain
{
    public enum TerrainType
    {
        Background,
        Platform,
    }

    [Serializable]
    public class PooledTerrain
    {
        public int amount;
        public GameObject obj;
        [HideInInspector] public List<GameObject> object_list;
    }

    public class TerrainManager : MonoBehaviour
    {
        [SerializeField] private List<PooledTerrain> pooled_platform_list = new List<PooledTerrain>();

        [SerializeField] private List<PooledTerrain> pooled_background_list = new List<PooledTerrain>();

        private void Start()
        {
            FillPooledTerrainList(pooled_platform_list);
            FillPooledTerrainList(pooled_background_list);
        }

        public void GetPooledPlatform(Vector3 vect)
        {
            GameObject terrain = null;
            int index = Random.Range(0, pooled_platform_list.Count);

            for (int i = 0; i < pooled_platform_list[index].object_list.Count; i++)
            {
                if (!pooled_platform_list[index].object_list[i].activeInHierarchy)
                {
                    terrain = pooled_platform_list[index].object_list[i];
                }
            }
            terrain.transform.SetPositionAndRotation(vect, Quaternion.identity);
            terrain.SetActive(true);
        }

        public void GetPooledBackground(Vector3 vect)
        {
            GameObject background = null;
            int index = Random.Range(0, pooled_background_list.Count);

            for (int i = 0; i < pooled_background_list[index].object_list.Count; i++)
            {
                if (!pooled_background_list[index].object_list[i].activeInHierarchy)
                {
                    background = pooled_background_list[index].object_list[i];
                }
            }
            background.transform.SetPositionAndRotation(vect, Quaternion.identity);
            background.SetActive(true);
        }

        private void FillPooledTerrainList(List<PooledTerrain> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].amount; j++)
                {
                    GameObject pooled_obj = Instantiate(list[i].obj);
                    pooled_obj.SetActive(false);
                    list[i].object_list.Add(pooled_obj);
                }
            }
        }
    }
}
