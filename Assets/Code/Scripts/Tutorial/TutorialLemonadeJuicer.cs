using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialLemonadeJuicer : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;
    private bool tutorialFirstTime = true;
    private bool isWaitingForSelectExit = false;

    public bool IsWaitingForSelectExit
    {
        get { return isWaitingForSelectExit; }
        set { isWaitingForSelectExit = value; }
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        if (isTutorial && tutorialFirstTime && isWaitingForSelectExit && args.interactableObject.transform.gameObject.CompareTag("Basic Lemonade"))
        {
            tutorialProceedToNextStep.Invoke();
            isWaitingForSelectExit = false;
            tutorialFirstTime = false;
        }
    }
}
