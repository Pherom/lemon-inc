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
            Destroy(other.gameObject);
            CustomerOrder orderStatus = transform.parent.gameObject.GetComponent<OrderHolder>().GetOrderStatus();
            orderStatus.AddSugar();
            if (sugaredLemonadePrefab != null)
            {
                Destroy(transform.parent.gameObject);
                GameObject newDrink = Instantiate(sugaredLemonadePrefab, transform.parent.transform.position, transform.parent.transform.rotation);
                newDrink.GetComponent<OrderHolder>().SetOrderStatus(orderStatus);
            }
        }
    }
}
