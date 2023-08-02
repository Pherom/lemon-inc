using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMinty : MonoBehaviour
{
    [SerializeField]
    private GameObject mintyLemonadePrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Mint"))
        {
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
            Instantiate(mintyLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
        }
    }
}
