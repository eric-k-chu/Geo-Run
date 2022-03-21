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

public class TerrainSpawner : MonoBehaviour
{
    [SerializeField] private TerrainType type;

    [Header("Length of terrain")]
    [SerializeField] private int length;

    [Header("Disable terrain after seconds")]
    [SerializeField] private float time;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 spawn_position_1 = new Vector3(transform.position.x,
                transform.position.y, transform.position.z + length);

            GameObject obj;
            int max = 1;
            int index = 0;
            if (type == TerrainType.Background)
            {
                index = 0;
            }
            else if (type == TerrainType.Platform)
            {
                max = PooledObjectManager.instance.pooled_object_list.Count;
                index = Random.Range(1, max);
            }
            obj = PooledObjectManager.instance.GetPooledObject(index);
            obj.transform.position = spawn_position_1;
            obj.transform.rotation = Quaternion.identity;
            obj.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisableObjectAfterSeconds());
        }
    }

    IEnumerator DisableObjectAfterSeconds()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
