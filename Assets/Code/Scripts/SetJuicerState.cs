using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class SetJuicerState : MonoBehaviour
{
    [SerializeField]
    private GameObject lemonJuicePrefab;
    private GameObject closed;
    private GameObject opened;
    public AudioClip mistakeSound;
    public AudioSource source;

    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    private bool tutorialSecondTime = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep1;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep2;

    void Start()
    {
        closed = gameObject.transform.GetChild(0).gameObject;
        opened = gameObject.transform.GetChild(1).gameObject;
        opened.SetActive(false);
    }



    public void MakeHandleUnselectable(SelectEnterEventArgs args)
    {
        if (gameObject.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.CompareTag("Basic Lemonade"))
        {
            closed.GetComponent<XRSimpleInteractable>().enabled = false;
        }
    }

    public void MakeHandleSelectable(SelectExitEventArgs args)
    {
        closed.GetComponent<XRSimpleInteractable>().enabled = true;
    }
    public void ToggleState(SelectEnterEventArgs args)
    {

        if (opened.activeSelf)
        {
            //Check if lemon in socket and drinking glass in socket
            if (opened.GetComponent<XRSocketInteractor>().hasSelection)
            {
                if (!gameObject.GetComponent<XRSocketInteractor>().hasSelection || gameObject.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.CompareTag("Basic Lemonade"))
                {
                    var controller = args.interactorObject.transform.GetComponent<ActionBasedController>();
                    HapticController.SendHaptics(controller, 0.6f, 1f);
                    source.PlayOneShot(mistakeSound);
                    return;
                }

                GameObject drinkingGlass = gameObject.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
                GameObject lemonSlice = opened.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
                GameObject lemonJuice = Instantiate(lemonJuicePrefab, drinkingGlass.transform.position, drinkingGlass.transform.rotation);
                lemonJuice.GetComponent<OrderHolder>().GetOrderStatus().SetDrinkType(DrinkType.LEMONADE);
                Destroy(drinkingGlass);
                Destroy(lemonSlice);
            }
        }

        closed.SetActive(!closed.activeSelf);
        opened.SetActive(!opened.activeSelf);

        if (isTutorial)
        {
            if (tutorialFirstTime)
            {
                tutorialProceedToNextStep1.Invoke();
                tutorialFirstTime = false;
                tutorialSecondTime = true;
            }
            else if (tutorialSecondTime)
            {
                tutorialProceedToNextStep2.Invoke();
                tutorialSecondTime = false;
            }
        }
    }
}
