using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] regularVehiclePrefabs;

    [SerializeField]
    private GameObject[] emergencyVehiclePrefabs;

    [SerializeField]
    private float startDelay = 2f;

    [SerializeField]
    private float spawnInterval = 5f;

    
    private Vector3 leftSpawnPosition = new Vector3(-25f,0f, 4.2f);

   
    private Vector3 rightSpawnPosition = new Vector3(25f, 0f, 9f);

    
    private Vector3 leftSpawnRotation = new Vector3(0f, -90f, 0f);

   
    private Vector3 rightSpawnRotation = new Vector3(0f, 90f, 0f);

    [SerializeField]
    [Range(0, 100)]
    private int percentChanceForEmergencyVehicle;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCar", startDelay, spawnInterval);
       

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnRandomCar()
    {

        int percent = Random.Range(0, 100);
        bool emergency = false;
        int carIndex;
        GameObject childObject;

        if (percent < percentChanceForEmergencyVehicle)
        {
            emergency = true;
        }

        // Randomly instantiate one car from Prefabs array
        if (emergency)
        {
            carIndex = Random.Range(0, emergencyVehiclePrefabs.Length);
        }
        else
        {
            carIndex = Random.Range(0, regularVehiclePrefabs.Length);
        }

        // probability for car to come from the left or right side 
        float leftOrRightProb = Random.Range(-1, 1);
        Vector3 position, rotation;

        if(leftOrRightProb >= 0)
        {
            position = leftSpawnPosition;
            rotation = leftSpawnRotation;
        }
        else
        {
            position = rightSpawnPosition;
            rotation = rightSpawnRotation;
        }

        if (!emergency)
        {
            childObject = Instantiate(regularVehiclePrefabs[carIndex], position, Quaternion.Euler(rotation));
        }
        else
        {
            childObject = Instantiate(emergencyVehiclePrefabs[carIndex], position, Quaternion.Euler(rotation));
        }
        childObject.transform.parent = gameObject.transform;
    }
}
