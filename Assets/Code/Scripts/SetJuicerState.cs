using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetJuicerState : MonoBehaviour
{
    private GameObject closed;
    private GameObject opened;

    public void Start()
    {
        closed = gameObject.transform.GetChild(0).gameObject;
        opened = gameObject.transform.GetChild(1).gameObject;
        opened.SetActive(false);
    }

    public void ToggleState()
    {
        closed.SetActive(!closed.activeSelf);
        opened.SetActive(!opened.activeSelf);
    }
}
