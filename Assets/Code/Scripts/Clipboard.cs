using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Clipboard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameLabel;
    [SerializeField] TextMeshProUGUI drinkTypeLabel;
    [SerializeField] TextMeshProUGUI sugarCountLabel;
    [SerializeField] TextMeshProUGUI addedIngredientLabel;


    public void UpdateClipboard(string customerName, CustomerOrder order)
    {
        nameLabel.text = customerName;
        sugarCountLabel.text = order.GetSugarCount().ToString();
        if (order.GetDrinkType() == DrinkType.PINK_LEMONADE)
        {
            drinkTypeLabel.text = "<sprite index=125>";
        }
        else
        {
            drinkTypeLabel.text = "<sprite index=4>";
        }


        if (!order.IsAddedIngredientIncluded())
        {
            addedIngredientLabel.text = "☐";
            addedIngredientLabel.text = "No";

        }
        else
        {
            addedIngredientLabel.text = "☑";
            addedIngredientLabel.text = "Yes";

        }

    }



}
