using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; 

public class UpdateOrderSummaryText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sugarCount;
    public void UpdateOrderDetails(SelectEnterEventArgs args)
    {
        
        XRBaseInteractable dish = args.interactableObject as XRBaseInteractable;
        OrderHolder orderWrapper = dish.transform.gameObject.GetComponent<OrderHolder>();

        if (orderWrapper != null && sugarCount != null)
        {
            Order drink = orderWrapper.GetOrder();
            Debug.Log($"Order {drink.drinkType.ToString()} with suger cubes");
            sugarCount.text = drink.sugerCubeCount.ToString();
        }
       
    }
}
