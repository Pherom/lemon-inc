using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Respawnable : MonoBehaviour
{
    private Vector3 spawnPoint;
    private Quaternion spawnRotation;

    public void Awake()
    {
        spawnPoint = transform.position;
        spawnRotation = transform.rotation;
    }

    public void Respawn()
    {
        Rigidbody rigidBody = transform.gameObject.GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        transform.position = spawnPoint;
        transform.rotation = spawnRotation;
    }

}
