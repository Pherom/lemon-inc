using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryCollision : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider)
    {
        Respawnable respawnable = collider.gameObject.GetComponent<Respawnable>();
        Destroyable destroyable = collider.gameObject.GetComponent<Destroyable>();

        if (respawnable != null)
        {
            respawnable.Respawn();
        }

        else if (destroyable != null)
        {
            destroyable.RemoveFromExistence();
        }
    }
}
