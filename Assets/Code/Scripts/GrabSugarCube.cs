using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class GrabSugarCube : MonoBehaviour
{

    [SerializeField]
    private GameObject sugarCubePrefab;


    public void GrabSugar(SelectEnterEventArgs args)
    {
        var newSugarCube = Instantiate(sugarCubePrefab, args.interactorObject.transform.position, args.interactorObject.transform.rotation);
        (GameObject.Find("XR Interaction Manager")).GetComponent<XRInteractionManager>().SelectEnter(args.interactorObject, newSugarCube.GetComponent<XRGrabInteractable>());
    }
}
