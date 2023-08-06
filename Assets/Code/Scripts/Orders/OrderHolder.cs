using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderHolder : MonoBehaviour
{
    // Start is called before the first frame update
    CustomerOrder orderStatus = CustomerOrder.GetEmptyOrder();

    public CustomerOrder GetOrderStatus() { return orderStatus; }

    public void SetOrderStatus(CustomerOrder updatedOrder) {
        //if (updatedOrder == null) return;
        this.orderStatus = updatedOrder;
        
    }
    public override string ToString()
    {
        string result = string.Format("Drink updated: drink_type:{0} sugar:{1} mint:{2}\n",orderStatus.GetDrinkType().ToString(),
            orderStatus.GetSugarCount(), orderStatus.IsAddedIngredientIncluded());

        return result; 
    }


}

