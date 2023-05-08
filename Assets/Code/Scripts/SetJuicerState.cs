using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetJuicerState : MonoBehaviour
{
    [SerializeField]
    private GameObject lemonJuicePrefab;
    private GameObject closed;
    private GameObject opened;

    void Start()
    {
        closed = gameObject.transform.GetChild(0).gameObject;
        opened = gameObject.transform.GetChild(1).gameObject;
        opened.SetActive(false);
    }

    public void ToggleState()
    {
        if (opened.activeSelf)
        {
            //Check if lemon in socket and drinking glass in socket
            if (opened.GetComponent<XRSocketInteractor>().hasSelection)
            {
                if (!gameObject.GetComponent<XRSocketInteractor>().hasSelection || gameObject.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.CompareTag("Full Glass"))
                {
                    return;
                }

                GameObject drinkingGlass = gameObject.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
                GameObject lemonSlice = opened.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject;
                Instantiate(lemonJuicePrefab, drinkingGlass.transform.position, drinkingGlass.transform.rotation);
                Destroy(drinkingGlass);
                Destroy(lemonSlice);
            }
        }

        closed.SetActive(!closed.activeSelf);
        opened.SetActive(!opened.activeSelf);
    }
}
