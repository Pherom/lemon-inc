using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class CustomerSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] customerPrefabs;
    private Vector3[] spawnPositions =
    {
        new Vector3(0.5f, 0.2f, 12)
    };
    private Quaternion[] spawnRotations =
    {
        new Quaternion(0, 180, 0, 0)
    };

    public void OnCustomerSpawnRequest(string[] values)
    {
        if (values[0] == "Next customer")
        {
            int customerPrefabIndex = Random.Range(0, customerPrefabs.Length);
            int spawnPointIndex = Random.Range(0, spawnPositions.Length);
            Instantiate(customerPrefabs[customerPrefabIndex], spawnPositions[spawnPointIndex], spawnRotations[spawnPointIndex]);
        }
    }


}
