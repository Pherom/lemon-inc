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

   
    public void DisplayOrderSummary(SelectEnterEventArgs args)
    {
        resetCanvas.gameObject.SetActive(false);
        welcomeCanvas.gameObject.SetActive(false);
        //XRBaseInteractable dish = args.interactableObject as XRBaseInteractable;
        //OrderHolder order = dish.transform.gameObject.GetComponent<OrderHolder>();
        StartCoroutine("ShowOrderSummary");
    }

    public void ShowResetMenu()
    {
        resetCanvas.gameObject.SetActive(true);
        welcomeCanvas.gameObject.SetActive(false);
        orderSummaryCanvas.gameObject.SetActive(false);
    }

    private IEnumerator ShowOrderSummary()
    {
        orderSummaryCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        orderSummaryCanvas.gameObject.SetActive(false);
    }

    
}
