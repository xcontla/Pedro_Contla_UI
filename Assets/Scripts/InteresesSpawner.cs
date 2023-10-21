using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteresesSpawner : MonoBehaviour
{
    public GameObject[] interesPrefab;
    public Vector3 interesAreaRange;
    public Transform[] spawnpoints;

    public float spawntime;

    private int numOfInt;
    void Start()
    {
        numOfInt = 0;
        StartCoroutine("SpawnIntereses");
        InventorySystem.Instance.onInventoryChangedEventCallback += OnUpdateInventory2;
    }

    // Update is called once per frame
    public IEnumerator SpawnIntereses()
    {

       
        yield return new WaitForSeconds(spawntime);
        while ((numOfInt < 1)) { 
        for (int i = 0; i < spawnpoints.Length - 1; i++)
            {
                Vector3 offset = new Vector3(Random.Range(-interesAreaRange.x, interesAreaRange.x),
                                           interesAreaRange.y,
                                           Random.Range(-interesAreaRange.z, interesAreaRange.z));
                int spoint = Random.Range(0, spawnpoints.Length - 1);
                Instantiate(
                    interesPrefab[Random.Range(0, interesPrefab.Length-1)],
                    spawnpoints[spoint].position + offset,
                    Quaternion.identity, spawnpoints[spoint]);
            numOfInt++;
        }

        }
    }

    public void OnUpdateInventory2()
    {

        numOfInt--;
        StartCoroutine(SpawnIntereses());
    }

}
