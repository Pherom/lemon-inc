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
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep1;
    [SerializeField]
    private UnityEvent tutorialProceedToNextStep2;

    void Update()
    {
        if (isTutorial && tutorialFirstTime)
        {
            XRSocketInteractor socketInteractor = transform.gameObject.GetComponent<XRSocketInteractor>();
            
            if (socketInteractor.hasSelection)
            {
                GameObject selectedInteractable = socketInteractor.GetOldestInteractableSelected().transform.gameObject;
                if (selectedInteractable.CompareTag("Basic Lemonade"))
                {
                    tutorialFirstTime = false;
                    StartCoroutine(task(selectedInteractable));
                }
            }
        }
    }

    private IEnumerator task(GameObject selectedInteractable)
    {
        tutorialProceedToNextStep1.Invoke();
        yield return new WaitForSeconds(5f);
        Destroy(selectedInteractable);
        tutorialProceedToNextStep2.Invoke();
    }
}
