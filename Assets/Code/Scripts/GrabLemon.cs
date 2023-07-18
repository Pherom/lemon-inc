using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabLemon : MonoBehaviour
{
    [SerializeField]
    private GameObject lemonPrefab;


    public void GrabNewLemon(SelectEnterEventArgs args)
    {
        var newLemon = Instantiate(lemonPrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newLemon.GetComponent<XRGrabInteractable>());
    }
}
