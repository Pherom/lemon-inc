using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class GrabNewGlass : MonoBehaviour
{
    [SerializeField]
    private GameObject glassPrefab;
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;

    public void GrabGlass(SelectEnterEventArgs args)
    {
        var newGlass = Instantiate(glassPrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newGlass.GetComponent<XRGrabInteractable>());
        if (isTutorial && tutorialFirstTime)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
