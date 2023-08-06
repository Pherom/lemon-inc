using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class ShowCustomerMessages : MonoBehaviour
{
    [Tooltip("The text mesh the message is output to")]
    public TextMeshProUGUI messageOutput = null;

    // What happens once the list is completed
    public UnityEvent OnComplete = new UnityEvent();


    [Tooltip("The list of messages that are shown")]
    [TextArea] public List<string> messages = new List<string>();
    [SerializeField] Customer customer;
    private int index = 0;

    private void Start()
    {
        if (customer == null)
        {
            customer = GetComponent<Customer>();
        }
        else
        {
            this.SetMessages(customer.GetMessages());
        }
    }

    public void NextMessage()
    {
        if (messages.Count == 0)
        {
            this.SetMessages(customer.GetMessages());
            Debug.Log(string.Format("Pulled {0} messages from customer", messages.Count));
            this.ShowMessage();
            return;
        }

        if (!customer.IsHoverEntered) { return; }

        int newIndex = ++this.index % this.messages.Count;

        if (newIndex < this.index)
        {
            this.OnComplete.Invoke();
            newIndex = 0; 
        }
        else
        {
            this.ShowMessage();
        }
    }

    public void PreviousMessage()
    {
        this.index = --this.index % this.messages.Count;
        this.ShowMessage();
    }

    private void ShowMessage()
    {
        this.messageOutput.text = this.messages[Mathf.Abs(index)];
    }

    public void ShowMessageAtIndex(int value)
    {
        index = value;
        ShowMessage();
    }


    public void SetMessages(List<string> messages)
    {
        this.messages.Clear();
        this.messages.AddRange(messages);
        ShowMessage();

    }

    public void SayThanks()
    {
        string thanksMessage = "Thank u";
        this.messages.Clear();
        this.messages.Add(thanksMessage);
        this.messageOutput.text = thanksMessage;
    }
}

