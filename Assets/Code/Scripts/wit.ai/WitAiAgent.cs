using System.Collections;
using System.Collections.Generic;
using Meta.WitAi;
using Meta.WitAi.Json;
using Meta.WitAi.Data.Entities;
using UnityEngine;
public class WitAiAgent : MonoBehaviour
{
    [SerializeField]
    CustomerManager customerManager;
    [SerializeField]
    TutorialCustomerManager tutorialCustomerManager;
    [SerializeField]
    bool isTutorial = false;
    string INTENT = "order_ready";

  
    public void OnResponse(WitResponseNode witResponse)
    {
        Debug.Log("Wit response received:" + witResponse.ToString());
        if (witResponse.GetIntentName() != INTENT)
        {
            Debug.Log("Unrecognized intent " + witResponse.GetIntentName());
            return; 
        }

        WitEntityData entity = witResponse.GetFirstWitEntity("wit$contact:contact");
        if(entity == null)
        {
            Debug.Log("Contact entity was not recognized in voice command");
            return;
        }
        else
        {
            string customerName = entity.body;
            Debug.Log("Customer name recognized " + customerName);
            if (isTutorial)
            {
                tutorialCustomerManager.AcceptOrderByCustomerName(customerName);
            }
            else
            {
                customerManager.AcceptOrderByCustomerName(customerName);
            }
        }

    }
}
