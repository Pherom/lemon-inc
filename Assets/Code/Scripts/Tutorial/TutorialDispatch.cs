using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialDispatch : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    private bool tutorialFirstTime = true;
    private bool tutorialSecondTime = false;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep1;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep2;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep3;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep4;
    void Update()
    {
        if (isTutorial)
        {
            XRSocketInteractor socketInteractor = transform.gameObject.GetComponent<XRSocketInteractor>();
            
            if (socketInteractor.hasSelection)
            {
                GameObject selectedInteractable = socketInteractor.GetOldestInteractableSelected().transform.gameObject;
                if (tutorialFirstTime && selectedInteractable.CompareTag("Basic Lemonade"))
                {
                    tutorialFirstTime = false;
                    StartCoroutine(task1(selectedInteractable));
                    tutorialSecondTime = true;
                }
                else if (tutorialSecondTime && selectedInteractable.CompareTag("Sugared Minty Pink Lemonade"))
                {
                    tutorialSecondTime = false;
                    StartCoroutine(task2(selectedInteractable));
                }
            }
        }
    }

    private IEnumerator task1(GameObject selectedInteractable)
    {
        tutorialProceedToNextStep1.Invoke();
        yield return new WaitForSeconds(5f);
        Destroy(selectedInteractable);
        tutorialProceedToNextStep2.Invoke();
    }

    private IEnumerator task2(GameObject selectedInteractable)
    {
        tutorialProceedToNextStep3.Invoke();
        yield return new WaitForSeconds(5f);
        tutorialProceedToNextStep4.Invoke();
    }
}
