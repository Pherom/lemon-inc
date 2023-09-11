using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class CustomerMessages : MonoBehaviour
{
    [Tooltip("The text mesh the message is output to")]
    public TextMeshProUGUI messageOutput = null;

    // What happens once the list is completed
    public UnityEvent OnComplete = new UnityEvent();



    [Tooltip("The list of messages that are shown")]
    [TextArea] public List<string> messages = new List<string>();
    [SerializeField] Customer customer;
    private int index = 0;
    [SerializeField]
    private bool isTutorial = false;

    private void Start()
    {
        if (isTutorial)
        {
            SetMessages(transform.gameObject.GetComponent<Customer>().GetMessages());
        }
    }


    [ContextMenu("Show Next Message")]
    public void NextMessage()
    {
        if (!customer.IsHoverEntered) return;

        if (messages.Count == 0)
        {
            this.SetMessages(customer.GetMessages());
        }
        else
        {
            int newIndex = ++this.index % this.messages.Count;

            if (newIndex < this.index)
            {
                this.OnComplete.Invoke();
                this.index = 0;
            }
        }
        this.ShowMessage();
      
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

    public void SayThanks(string thanksMessage = "Thank you!")
    {
        this.messages.Clear();
        this.messages.Add(thanksMessage);
        this.messageOutput.text = thanksMessage;
        if (thanksMessage != "Thank you!")
        {
            this.messageOutput.fontSize = 12;
        }
    }

    public void ResetMessages()
    {
        this.index = 0;
        ShowMessage();
    }


}

