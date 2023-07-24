using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    
    private float speed = 6f;

    [SerializeField]
    private float xRange = 32f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x) > xRange)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        


    }

}
