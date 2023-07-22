using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro; 

public class UpdateOrderSummaryText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI orderDetails;
    public void UpdateOrderDetails(SelectEnterEventArgs args)
    {
        orderDetails.text = "1\n2\n"+ ((char)0x221A).ToString();
    }
}
