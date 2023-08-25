using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

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
    void Start()
    {
        order = new CustomerOrder();
        IsHoverEntered = false;
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
            CustomerManager customerManager = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
            Destroy(dispatchSocInt.GetOldestInteractableSelected().transform.gameObject);
            customerManager.SendCustomerAway(transform.parent.gameObject);
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
        msgs.Add(string.Format("I would like {0} please", drink_type));
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

}
