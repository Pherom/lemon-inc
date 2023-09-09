using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Knife : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    [SerializeField] float vibrationIntensity = 0.7f;
    [SerializeField] float vibrationInterval = 1.4f;


    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void SendVibrationsToContoller()
    {
        if (grabInteractable.isSelected)
        {
            var controller = grabInteractable.GetOldestInteractorSelecting().transform.GetComponent<ActionBasedController>();
            HapticController.SendHaptics(controller, vibrationIntensity, vibrationInterval);
        }
    }

    public bool IsKnifeSelected()
    {
        return grabInteractable.isSelected;
    }
}
