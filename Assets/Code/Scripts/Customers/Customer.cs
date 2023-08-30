using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    public enum Gender
    {
        Male,
        Female
    }

    CustomerOrder order;
    [SerializeField] string[] welcomeMessages = {"Howdy", "Hi Pal", "Ma nishma", "Hi :)"};
    [SerializeField] GameObject chatBubble;
    [SerializeField] Gender gender;
    [SerializeField] string customerName;
    [SerializeField] bool isTutorial = false;
    [SerializeField] int tutorialOrderSugarAmount = 1;
    [SerializeField] bool tutorialOrderAddIngredient = true;
    [SerializeField] DrinkType tutorialOrderDrinkType = DrinkType.PINK_LEMONADE;
    [SerializeField] UnityEvent tutorialProceedToNextStep;
    
	[SerializeField] float waitAfterAcceptingOrder = 1f;

    private CustomerMessages messages; 
    private CustomerManager customerManger; 

    void Start()
    {
        messages = this.GetComponent<CustomerMessages>();
        customerManger = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
        IsHoverEntered = false;
    }
    public Gender CustomerGender
    {
        get { return gender; }
    }
    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }
    // Start is called before the first frame update

    public bool IsHoverEntered;

    private void Awake()
    {
        if (isTutorial)
        {
            order = new CustomerOrder(tutorialOrderSugarAmount, tutorialOrderAddIngredient, tutorialOrderDrinkType);
        }
        else
        {
            order = new CustomerOrder();
        }
    }


    public void HoverEntered()
    {
        IsHoverEntered = true;
        chatBubble.gameObject.SetActive(true);
    }
    public void HoverExited()
    {
        IsHoverEntered = false;
        chatBubble.gameObject.SetActive(false);

    }
    public void AttemptToTakeOrder()
    {
        XRSocketInteractor dispatchSocInt = GameObject.FindGameObjectWithTag("Dispatch").GetComponent<XRSocketInteractor>();

        if (dispatchSocInt.hasSelection)
        {
            if (isTutorial)
            {
				messages.SayThanks();
                Destroy(dispatchSocInt.GetOldestInteractableSelected().transform.gameObject);
                Debug.Log(transform.parent.gameObject.name);
                transform.parent.gameObject.GetComponent<CustomerNavMesh>().IsDone = true;
                tutorialProceedToNextStep.Invoke();
            }
            else
            {
				messages.SayThanks();
            	Destroy(dispatchSocInt.GetOldestInteractableSelected().transform.gameObject);
            	Debug.Log(transform.parent.gameObject.name);
            	var customer =  transform.parent.gameObject;
            	StartCoroutine(sendCustomerAway(customer));
            }
        }
    }

    public List<string> GetMessages()
    {
        List<string> msgs = new List<string>();
        int index = Random.Range(0, welcomeMessages.Length);
        string welcomeMessage = welcomeMessages[index] + "\nMy name is " + customerName;
        msgs.Add(welcomeMessage);
        string drink_type = order.GetDrinkType().ToString().ToLower();
        int sugar_count = order.GetSugarCount();
        bool mint = order.IsAddedIngredientIncluded();
        msgs.Add(string.Format("I would like {0} please", drink_type.Replace('_', ' ')));
        if (sugar_count == 0)
        {
            msgs.Add("With no sugar");
        }
        else
        {
            msgs.Add(string.Format("With {0} sugar cubes",sugar_count));
        }

        if (mint)
        {
            msgs.Add("and add mint :)");
        }


        return msgs; 
    }

    [ContextMenu("Show chat bubble")]
    public void ShowChatBubble()
    {
        GameObject chatBubble = gameObject.transform.GetChild(0).gameObject;
        chatBubble.SetActive(true);
    }

}
