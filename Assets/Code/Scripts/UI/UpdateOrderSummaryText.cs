using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; 

public class UpdateOrderSummaryText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI sugarCountLabel;
    [SerializeField] TextMeshProUGUI addedIngredientLabel;
    [SerializeField] TextMeshProUGUI emojiLabel;
    public void UpdateOrderDetails(SelectEnterEventArgs args)
    {
        
        XRBaseInteractable dish = args.interactableObject as XRBaseInteractable;
        OrderHolder orderWrapper = dish.transform.gameObject.GetComponent<OrderHolder>();
        if (sugarCountLabel == null || addedIngredientLabel == null || emojiLabel == null) return;
        if (orderWrapper != null)
        {
            CustomerOrder drink = orderWrapper.GetOrderStatus();
 
            sugarCountLabel.text = drink.GetDrinkType().ToString();

            if (drink.IsAddedIngredientIncluded() && addedIngredientLabel != null)
            {
                addedIngredientLabel.text = "Yes";
            }
            else
            {
                addedIngredientLabel.text = "No";
            }

            if (drink.GetDrinkType() == DrinkType.PINK_LEMONADE)
            {
                emojiLabel.text = "<sprite index=125>";
            }else
            {
                emojiLabel.text = "<sprite index=4>";
            }
        }
       
    }
}
