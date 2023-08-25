using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.WitAi;
using UnityEngine.InputSystem;

public class ActivateVoice : MonoBehaviour
{
    [SerializeField]
    private Wit wit;

    [SerializeField]
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wit == null)
        {
            wit = GetComponent<Wit>();
        }
    }

    public void TriggerPressed()
    { 
        wit.Activate();
        audioSource.Play();
        Debug.Log("Trigger pressed");
    }
}
