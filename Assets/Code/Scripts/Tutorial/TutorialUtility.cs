using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialUtility : MonoBehaviour
{
    [SerializeField]
    private bool isTutorial = false;
    [SerializeField]
    private UnityEvent tutorialLemonadeProceedToNextStep;
    [SerializeField]
    private UnityEvent tutorialSugaredLemonadeProceedToNextStep;
    [SerializeField]
    private UnityEvent tutorialSugaredMintyLemonadeProceedToNextStep;
    [SerializeField]
    private UnityEvent tutorialSugaredMintyPinkLemonadeProceedToNextStep;
    private bool lemonadeStep = true;
    private bool sugaredLemonadeStep = false;
    private bool sugaredMintyLemonadeStep = false;
    private bool sugaredMintyPinkLemonadeStep = false;

    public bool SugaredLemonadeStep
    {
        get { return sugaredLemonadeStep; }
        set { sugaredLemonadeStep = value; }
    }

    public bool SugaredMintyLemonadeStep
    {
        get {  return sugaredMintyLemonadeStep; }
        set { sugaredMintyLemonadeStep = value; }
    }

    public bool SugaredMintyPinkLemonadeStep
    {
        get { return sugaredMintyPinkLemonadeStep; }
        set { sugaredMintyPinkLemonadeStep = value; }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTutorial)
        {
            if (lemonadeStep && GameObject.FindWithTag("Basic Lemonade") != null)
            {
                tutorialLemonadeProceedToNextStep.Invoke();
                lemonadeStep = false;
            }
            else if (sugaredLemonadeStep && GameObject.FindWithTag("Sugared Lemonade") != null)
            {
                tutorialSugaredLemonadeProceedToNextStep.Invoke();
                sugaredLemonadeStep = false;
            }
            else if (sugaredMintyLemonadeStep && GameObject.FindWithTag("Sugared Minty Lemonade") != null)
            {
                tutorialSugaredMintyLemonadeProceedToNextStep.Invoke();
                sugaredMintyLemonadeStep = false;
            }
            else if (sugaredMintyPinkLemonadeStep && GameObject.FindWithTag("Sugared Minty Pink Lemonade") != null)
            {
                tutorialSugaredMintyPinkLemonadeProceedToNextStep.Invoke();
                sugaredMintyPinkLemonadeStep = false;
            }
        }
    }
}
