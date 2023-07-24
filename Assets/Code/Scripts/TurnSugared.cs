using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSugared : MonoBehaviour
{
    [SerializeField]
    private GameObject sugaredLemonadePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sugar"))
        {
            // Destroying lemon glass with no sugar
            Destroy(transform.parent.gameObject);

            // Destroying sugar cube 
            Destroy(other.gameObject);
            Instantiate(sugaredLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
        }
    }
}
