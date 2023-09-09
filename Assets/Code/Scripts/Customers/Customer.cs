using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class Customer : MonoBehaviour
{
    public enum Gender
    {
        Male,
        Female
    }

    [SerializeField] string[] welcomeMessages = {"Howdy", "Hi Pal", "Ma nishma", "Hi :)"};
    [SerializeField] GameObject chatBubble;
    [SerializeField] Gender gender;
    [SerializeField] string customerName;
    [SerializeField] bool isTutorial = false;
    [SerializeField] int tutorialOrderSugarAmount = 1;
    [SerializeField] bool tutorialOrderAddIngredient = true;
    [SerializeField] DrinkType tutorialOrderDrinkType = DrinkType.PINK_LEMONADE;
    [SerializeField] UnityEvent tutorialProceedToNextStep;
    [SerializeField] GameObject orderClipboardPrefab;

    private static readonly int happyScoreThreshold = 0;
    private CustomerMessages messages; 
    private CustomerManager customerManager;

    private GameObject orderClipboard = null;

    private static int[] happyEmojis = {15,19,21,25,26,33};
    private static int[] sadEmojis = {10,11,20};
    private CustomerOrder order;




    void Start()
    {
        messages = this.GetComponent<CustomerMessages>();
        customerManager = GameObject.FindGameObjectWithTag("CustomerManager").GetComponent<CustomerManager>();
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
            this.order = new CustomerOrder(tutorialOrderSugarAmount, tutorialOrderAddIngredient, tutorialOrderDrinkType);
        }
        else
        {
            this.order = new CustomerOrder();
        }

    }


    public void HoverEntered()
    {
        CustomerNavMesh navMesh = GetComponentInParent<CustomerNavMesh>();
        if (navMesh.IsUpNext)
        {
            IsHoverEntered = true;
            chatBubble.gameObject.SetActive(true);
        }
    }
    public void HoverExited()
    {
        CustomerNavMesh navMesh = GetComponentInParent<CustomerNavMesh>();
        if (navMesh.IsUpNext)
        {
            IsHoverEntered = false;
            chatBubble.gameObject.SetActive(false);
        }
    }
    public void AttemptToTakeOrder()
    {
        XRSocketInteractor dispatchSocInt = GameObject.FindGameObjectWithTag("Dispatch").GetComponent<XRSocketInteractor>();

        if (dispatchSocInt.hasSelection)
        {
            GameObject drink = dispatchSocInt.GetOldestInteractableSelected().transform.gameObject;
            OrderHolder orderSubmitted = drink.GetComponent<OrderHolder>();
            chatBubble.gameObject.SetActive(true);
            if(orderSubmitted != null)
            {
                int orderScore = CustomerOrder.Compare(this.order, orderSubmitted.GetOrderStatus());

                int emojiIndex = 15; // Default happy emoji

                if (orderScore >= Customer.happyScoreThreshold)
                {
                    emojiIndex = Customer.happyEmojis[Random.Range(0, Customer.happyEmojis.Length)];
                    messages.SayThanks(string.Format("<sprite index={0}>", emojiIndex));

                }
                else
                {
                    emojiIndex = Customer.sadEmojis[Random.Range(0, Customer.sadEmojis.Length)];
                    messages.SayThanks(string.Format("<sprite index={0}>", emojiIndex));

                }
            }
            else
            {
                messages.SayThanks();

            }

            Destroy(drink);
            transform.parent.gameObject.GetComponent<CustomerNavMesh>().IsDone = true;

            if (isTutorial)
            {
                tutorialProceedToNextStep.Invoke();
            }
            else
            {
                Invoke("sendCustomerAway", 1.5f);
            }

        }
    }


    private void sendCustomerAway()
    {
        var customer = transform.parent.gameObject;
        customerManager.SendCustomerAway(customer);
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


    public void CreateClipboardWithOrder()
    {
        if (this.orderClipboard == null)
        {
            Debug.Log("Creating clipboard for customer " + this.customerName);
            Vector3 clipboardSpawnPosition = new Vector3(5.18f, 1.35f, -2.3f);
            var clipboardSpawnRotation = Quaternion.Euler(new Vector3(270f, 230f, 309f));
            this.orderClipboard = Instantiate(this.orderClipboardPrefab, clipboardSpawnPosition, clipboardSpawnRotation);
            Clipboard clipboard = this.orderClipboard.GetComponent<Clipboard>();
            clipboard.UpdateClipboard(customerName, this.order);
        }
    }


    public void DeleteCustomerOrder()
    {
        if (this.orderClipboard)
        {
            Destroy(orderClipboard);
        }
    }

    private void OnDestroy()
    {
        if (this.orderClipboard)
        {
            Destroy(orderClipboard);
        }
    }




}
