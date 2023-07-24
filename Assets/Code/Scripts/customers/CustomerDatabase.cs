using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Customer
{
    string name;
    Order orderRequest; 

}
public class CustomerDatabase : MonoBehaviour
{
    private ArrayList customers; 
    // Start is called before the first frame update
    void Start()
    {
        customers = new ArrayList(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
