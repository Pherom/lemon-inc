using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (other.CompareTag("Slicer") == true)
        {
            Slice();
        }
    }
}
