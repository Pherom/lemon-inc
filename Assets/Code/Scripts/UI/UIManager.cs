using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas resetCanvas;
    [SerializeField] Canvas welcomeCanvas;
    [SerializeField] Canvas orderSummaryCanvas;
    [SerializeField] float displayOrderSummaryDuration = 1.8f;

   
    public void DisplayOrderSummary(SelectEnterEventArgs args)
    {
        if (resetCanvas != null)
            resetCanvas.gameObject.SetActive(false);
        if (welcomeCanvas != null)
            welcomeCanvas.gameObject.SetActive(false);
        //XRBaseInteractable dish = args.interactableObject as XRBaseInteractable;
        //OrderHolder order = dish.transform.gameObject.GetComponent<OrderHolder>();
        StartCoroutine("ShowOrderSummary");
    }

    public void ShowResetMenu()
    {
        if (resetCanvas != null)
            resetCanvas.gameObject.SetActive(true);
        if (welcomeCanvas != null)
            welcomeCanvas.gameObject.SetActive(false);
        orderSummaryCanvas.gameObject.SetActive(false);
    }

    private IEnumerator ShowOrderSummary()
    {
        orderSummaryCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayOrderSummaryDuration);
        orderSummaryCanvas.gameObject.SetActive(false);
    }

    public void HideOrderSummary()
    {
        orderSummaryCanvas.gameObject.SetActive(false);
    }

    
}
