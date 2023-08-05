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
            Destroy(transform.parent.gameObject);
            Destroy(other.gameObject);
            CustomerOrder orderStatus = GetComponent<OrderHolder>()?.GetOrderStatus();
            orderStatus?.AddSugar();
            GameObject newDrink = Instantiate(sugaredLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
            newDrink.GetComponent<OrderHolder>()?.SetOrderStatus(orderStatus);
        }
    }
}
