using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabMint : MonoBehaviour
{
    [SerializeField]
    private GameObject mintPrefab;

    public void GrabNewMint(SelectEnterEventArgs args)
    {
        var newMint = Instantiate(mintPrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newMint.GetComponent<XRGrabInteractable>());
    }
}
