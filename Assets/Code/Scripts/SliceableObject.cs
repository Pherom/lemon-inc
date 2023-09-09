using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SliceableObject : MonoBehaviour, ISliceable
{
    public Transform pfSliced;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Slice()
    {
        Destroy(gameObject);
        Instantiate(pfSliced, transform.position, transform.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        Knife knife = other.GetComponent<Knife>();
        if (knife == null) return; 
        if (knife.IsKnifeSelected())
        {
            knife.SendVibrationsToContoller();
            Slice();
        }
    }
}
