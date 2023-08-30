using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class GrabMint : MonoBehaviour
{
    [SerializeField]
    private GameObject mintPrefab;
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;

    public void GrabNewMint(SelectEnterEventArgs args)
    {
        var newMint = Instantiate(mintPrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        GameObject.Find("XR Interaction Manager").GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newMint.GetComponent<XRGrabInteractable>());
        if (isTutorial && tutorialFirstTime)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
