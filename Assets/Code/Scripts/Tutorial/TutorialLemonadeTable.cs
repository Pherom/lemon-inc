using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialLemonadeTable : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;
    private bool tutorialFirstTime = true;
    private bool isWaitingForLemonade = false;

    public bool IsWaitingForLemonade
    {
        get { return isWaitingForLemonade; }
        set { isWaitingForLemonade = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isTutorial && tutorialFirstTime && isWaitingForLemonade && other.gameObject.CompareTag("Basic Lemonade"))
        {
            tutorialProceedToNextStep.Invoke();
            isWaitingForLemonade = false;
            tutorialFirstTime = false;
        }
    }
}
