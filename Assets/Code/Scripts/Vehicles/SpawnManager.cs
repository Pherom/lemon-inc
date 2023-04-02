using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] vehiclePrefabs;

    [SerializeField]
    private float startDelay = 2f;

    [SerializeField]
    private float spawnInterval = 5f;

    
    private Vector3 leftSpawnPosition = new Vector3(-25f,0f, 4.2f);

   
    private Vector3 rightSpawnPosition = new Vector3(25f, 0f, 9f);

    
    private Vector3 leftSpawnRotation = new Vector3(0f, -90f, 0f);

   
    private Vector3 rightSpawnRotation = new Vector3(0f, 90f, 0f);

    

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
        

        // Randomly instantiate one car from Prefabs array 
        int carIndex = (int) Random.Range(0, vehiclePrefabs.Length);

        

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



       
        
      
      
        GameObject childObject = Instantiate(vehiclePrefabs[carIndex], position, Quaternion.Euler(rotation));
        childObject.transform.parent = gameObject.transform;
    }
}
