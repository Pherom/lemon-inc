using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialUtility : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep;
    private bool tutorialFirstTime = true;

    // Update is called once per frame
    void Update()
    {
        if (isTutorial && tutorialFirstTime && GameObject.FindWithTag("Basic Lemonade") != null)
        {
            tutorialProceedToNextStep.Invoke();
            tutorialFirstTime = false;
        }
    }
}
