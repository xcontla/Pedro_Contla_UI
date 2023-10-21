using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AptitudesSpawner : MonoBehaviour
{
    public GameObject[] aptitudPrefab;
    public Vector3 aptitudAreaRange;
    public Transform[] spawnpoints;


    public float spawntime;

    private int numOfApt;
    void Start()
    {
        numOfApt = 0;
        StartCoroutine("SpawnAptitudes");
        InventorySystem.Instance.onInventoryChangedEventCallback += OnUpdateInventory3;
    }

    // Update is called once per frame
    public IEnumerator SpawnAptitudes()
    {
        yield return new WaitForSeconds(spawntime);

        while ((numOfApt < 3))
        {
            for (int i = 0; i < spawnpoints.Length - 1; i++)
            {

                Vector3 offset = new Vector3(Random.Range(-aptitudAreaRange.x, aptitudAreaRange.x),
                                                    aptitudAreaRange.y,
                                                    Random.Range(-aptitudAreaRange.z, aptitudAreaRange.z));
                int spoint = Random.Range(0, spawnpoints.Length - 1);
                Instantiate(
                         aptitudPrefab[Random.Range(0, aptitudPrefab.Length-1)],
                         spawnpoints[spoint].position + offset,
                         Quaternion.identity, spawnpoints[spoint]);
                numOfApt++;
            }

        }
    }

    public void OnUpdateInventory3()
    {

        numOfApt--;
        StartCoroutine(SpawnAptitudes());
    }

}
