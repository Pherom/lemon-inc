using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCollision : MonoBehaviour
{

    public AudioClip[] shutterdGlassSFX;
    // Start is called before the first frame update
    private AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter for Glass");
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Colliding with the ground -- glass object to be destroyed..");
            int soundClipIndex = (int)Random.Range(0, shutterdGlassSFX.Length);
            source.PlayOneShot(shutterdGlassSFX[soundClipIndex]);
            Destroy(gameObject,3);
        }
    }
}
