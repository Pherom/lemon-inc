using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialKnife : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;

    private void OnCollisionEnter(Collision collision)
    {
        if (isTutorial && tutorialFirstTime && collision.collider.gameObject.CompareTag("Lemon"))
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
