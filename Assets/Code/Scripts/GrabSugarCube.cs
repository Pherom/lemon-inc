using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class GrabSugarCube : MonoBehaviour
{

    [SerializeField]
    private GameObject sugarCubePrefab;
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;


    public void GrabSugar(SelectEnterEventArgs args)
    {
        var newSugarCube = Instantiate(sugarCubePrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newSugarCube.GetComponent<XRGrabInteractable>());
        if (isTutorial && tutorialFirstTime)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
