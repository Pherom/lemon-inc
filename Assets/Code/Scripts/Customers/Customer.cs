using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    CustomerOrder order;
    [SerializeField] float thinkingTime = 0f;
    [SerializeField] string[] welcomeMessages = {"Howdy", "Hi Pal", "Ma nishma", "Hi :)"};
    [SerializeField] GameObject chatBubble; 
   
    // Start is called before the first frame update

    public bool IsHoverEntered;
    void Start()
    {
        order = new CustomerOrder();
        Debug.Log(order.ToString());
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

    }
    public List<string> GetMessages()
    {
        List<string> msgs = new List<string>();
        int index = Random.Range(0, welcomeMessages.Length);
        msgs.Add(welcomeMessages[index]);
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
