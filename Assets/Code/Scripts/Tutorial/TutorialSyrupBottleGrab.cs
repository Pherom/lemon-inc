using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class TutorialSyrupBottleGrab : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;
    private bool tutorialFirstTime = true;

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (isTutorial && tutorialFirstTime)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
