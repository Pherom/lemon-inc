using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class GrabLemon : MonoBehaviour
{
    [SerializeField]
    private GameObject lemonPrefab;
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;

    public void GrabNewLemon(SelectEnterEventArgs args)
    {
        var newLemon = Instantiate(lemonPrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newLemon.GetComponent<XRGrabInteractable>());
        if (isTutorial && tutorialFirstTime)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
