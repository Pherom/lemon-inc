using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialGlass : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStepEvent;
    private bool tutorialFirstTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isTutorial && tutorialFirstTime && other.gameObject.CompareTag("Empty Glass"))
        {
            tutorialProceedToNextStepEvent.Invoke();
            tutorialFirstTime = false;
        }
    }
}
