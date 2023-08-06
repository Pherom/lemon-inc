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
            Destroy(other.gameObject);
            CustomerOrder orderStatus = transform.parent.gameObject.GetComponent<OrderHolder>().GetOrderStatus();
            orderStatus.AddAdditionalIngredient();
            Destroy(transform.parent.gameObject);
            GameObject newDrink = Instantiate(mintyLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
            newDrink.GetComponent<OrderHolder>().SetOrderStatus(orderStatus);
        }
    }
}
