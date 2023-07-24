using UnityEngine;
using TMPro;



public class ShowCustomerDialog : MonoBehaviour
{
    [SerializeField]
    GameObject DialogChatBubble;

    [SerializeField]
    GameObject AcceptOrderDialogBox;

    [SerializeField]
    bool orderReady = false;

    [SerializeField]
    bool hoverAcceptOrderDialog;

    [SerializeField] TextMeshPro greeting;


    public void SetOrderReady(bool ready)
    {
        orderReady = ready; 
    }

    public void DisplayDialog()
    {
        if (orderReady)
        {
            AcceptOrderDialogBox.transform.gameObject.SetActive(true);
            DialogChatBubble.transform.gameObject.SetActive(false);
            hoverAcceptOrderDialog = true; 
        }
        else
        {
            DialogChatBubble.transform.gameObject.SetActive(true);
            AcceptOrderDialogBox.transform.gameObject.SetActive(true);
            hoverAcceptOrderDialog = false;

        }
    }

    public void AcceptOrder()
    {
        if (!hoverAcceptOrderDialog) return;
        AcceptOrderDialogBox.transform.gameObject.SetActive(false);
        DialogChatBubble.transform.gameObject.SetActive(true);
        greeting.text = "Thank youu sir";
    }

    public void DisableDialog()
    {
      
        AcceptOrderDialogBox.transform.gameObject.SetActive(false);
        hoverAcceptOrderDialog = false;
        DialogChatBubble.transform.gameObject.SetActive(false);
    }
}
