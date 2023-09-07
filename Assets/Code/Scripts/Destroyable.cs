using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public void RemoveFromExistence()
    {
        Destroy(gameObject, 3f);
    }
}
