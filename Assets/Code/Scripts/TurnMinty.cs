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
            CustomerOrder orderStatus = GetComponent<OrderHolder>()?.GetOrderStatus();
            orderStatus?.AddAdditionalIngredient();
            GameObject newDrink = Instantiate(mintyLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
            newDrink.GetComponent<OrderHolder>()?.SetOrderStatus(orderStatus);
        }
    }
}
