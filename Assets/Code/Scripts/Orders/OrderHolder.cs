using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHolder : MonoBehaviour
{
    // Start is called before the first frame update
    private CustomerOrder orderStatus = CustomerOrder.GetEmptyOrder();

    public CustomerOrder GetOrderStatus() { return orderStatus; }

    public void SetOrderStatus(CustomerOrder updatedOrder) {
        this.orderStatus = updatedOrder;
        
    }
    public override string ToString()
    {
        string result = string.Format("{0} {1} {2}\n",orderStatus.GetDrinkType().ToString(),
            orderStatus.GetSugarCount(), orderStatus.IsAddedIngredientIncluded());

        return result; 
    }


}

