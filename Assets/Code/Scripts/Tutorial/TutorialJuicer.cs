using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialJuicer : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;

    private void Update()
    {
        if (isTutorial && tutorialFirstTime && gameObject.GetComponent<XRSocketInteractor>().hasSelection)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
