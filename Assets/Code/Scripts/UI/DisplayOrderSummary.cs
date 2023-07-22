using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Full Glass"))
        {
            Debug.Log("Hello Full Glass");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Full Glass"))
        {
            Debug.Log("No Glass");
        }
        
    }
}
