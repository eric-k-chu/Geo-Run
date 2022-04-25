/*
PROJECT: Geo Run
MEMBERS: Eric Chu, Jake Wong
COURSE: CPSC 254-01
LICENSE: MIT License. For more information, click here https://github.com/ericchu1329/Geo-Run
DATE: 2022 February 17

This file contains the TerrainSpawner class, which spawns new terrain.
*/

using System.Collections;
using UnityEngine;

namespace GPEJ.Terrain
{
    public class TerrainSpawner : MonoBehaviour
    {
        [SerializeField] private Vector3EventChannel platform_channel;
        [SerializeField] private Vector3EventChannel background_channel;

        [SerializeField] private TerrainType type;

        [Header("Length of terrain")]
        [SerializeField] private float length;

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

                if (type == TerrainType.Background)
                {
                    background_channel.RaiseEvent(spawn_position_1);
                }
                else if (type == TerrainType.Platform)
                {
                    platform_channel.RaiseEvent(spawn_position_1);
                }              
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
