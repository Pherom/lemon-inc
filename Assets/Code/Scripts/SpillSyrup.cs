using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillSyrup : MonoBehaviour
{
    private ParticleSystem syrupParticleSystem;

    private void Start()
    {
        syrupParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, gameObject.transform.up) <= 90f)
        {
            if (!syrupParticleSystem.isPlaying)
            {
                syrupParticleSystem.Play();
            }
        }
        else
        {
            if (syrupParticleSystem.isPlaying)
            {
                syrupParticleSystem.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }
    }
}
