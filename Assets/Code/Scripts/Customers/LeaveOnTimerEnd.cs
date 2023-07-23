using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveOnTimerEnd : MonoBehaviour
{
    private GameObject customerManager;

    private void Start()
    {
        customerManager = GameObject.Find("CustomerManager");
    }

    public void Leave()
    {
        customerManager.GetComponent<CustomerManager>().SendCustomerAway(transform.parent.gameObject);
    }
}
