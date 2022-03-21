/*
NAME: GPEJ
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01

FILE DESCRIPTION:
This file contains the TerrainSpawner class, which will spawn new
terrain after the player enters the collision area
*/

using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GPEJ.Terrain
{
    public class TerrainSpawner : MonoBehaviour
    {
        [SerializeField] private TerrainType type;

        [Header("Length of terrain")]
        [SerializeField] private int length;

        [Header("Disable terrain after seconds")]
        [SerializeField] private float seconds;

        private WaitForSeconds timer;

        private void Start()
        {
            timer = new WaitForSeconds(seconds);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Vector3 spawn_position_1 = new Vector3(transform.position.x,
                    transform.position.y, transform.position.z + length);

                GameObject obj = null;
                int index = 0;

                if (type == TerrainType.Platform)
                {
                    int max = TerrainManager.instance.GetPooledListSize();
                    // list of platform objects start at position 1 in pool_list
                    // there is only one background model, so it is at position 0 in pool_list
                    index = Random.Range(1, max);
                }
                obj = TerrainManager.instance.GetPooledTerrain(index);
                obj.transform.SetPositionAndRotation(spawn_position_1, Quaternion.identity);
                obj.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                DisableTerrain();
            }
        }

        private void DisableTerrain()
        {
            StartCoroutine(DisableObjectAfterSeconds());
        }

        private IEnumerator DisableObjectAfterSeconds()
        {
            yield return timer;
            gameObject.SetActive(false);
        }
    }
}
