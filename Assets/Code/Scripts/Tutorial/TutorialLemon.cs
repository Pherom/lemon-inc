using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialLemon : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStepEvent;
    private bool tutorialFirstTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (isTutorial && tutorialFirstTime && other.gameObject.CompareTag("Lemon"))
        {
            tutorialProceedToNextStepEvent.Invoke();
            tutorialFirstTime = false;
        }
    }
}
