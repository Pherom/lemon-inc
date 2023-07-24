using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHolder : MonoBehaviour
{
    [SerializeField] Order order; 
    
    public void SetOrder(Order newOrder)
    {
        order = newOrder;
    }

    public Order GetOrder() {
        return order;
    }


    
}
