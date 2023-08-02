using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPink : MonoBehaviour
{
    [SerializeField]
    private GameObject pinkLemonadePrefab;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Pink Lemonade Syrup"))
        {
            Destroy(transform.gameObject);
            Instantiate(pinkLemonadePrefab, transform.position, transform.rotation);
        }
    }
}
