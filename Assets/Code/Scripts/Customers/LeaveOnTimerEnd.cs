using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOnTimerEnd : MonoBehaviour
{
    private CustomerManager customerManager;

    private void Start()
    {
        customerManager = GameObject.Find("CustomerManager").GetComponent<CustomerManager>();
    }

    public void Leave()
    {
        GameObject customer = transform.parent.gameObject;
        Customer customerData = customer.GetComponentInChildren<Customer>();
        customerData.LeaveOnTimerEnd();
    }
}
