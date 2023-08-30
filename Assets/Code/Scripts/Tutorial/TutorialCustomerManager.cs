using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCustomerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorialCustomer;

    public void AcceptOrderByCustomerName(string customerName)
    {
        Debug.Log("Trying to send customer away - " + customerName);

        Customer customerObject = tutorialCustomer.GetComponentInChildren<Customer>();
        if (customerObject.CustomerName == customerName)
        {
            //TODO Should uncomment this line - sending customer away only when order is present. 
            customerObject.AttemptToTakeOrder();
            Debug.Log("Sending customer away - " + customerName);
        }
    }
}
