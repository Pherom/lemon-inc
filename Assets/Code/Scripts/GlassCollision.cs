using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCollision : MonoBehaviour
{

    public AudioClip[] shutterdGlassSFX;


    // Start is called before the first frame update
    private AudioSource source;

    private OrderHolder orderHolder;


    void Start()
    {
        source = GetComponent<AudioSource>();
        orderHolder = gameObject.GetComponent<OrderHolder>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Colliding with the ground -- glass object to be destroyed..");
            int soundClipIndex = (int)Random.Range(0, shutterdGlassSFX.Length);
            source.PlayOneShot(shutterdGlassSFX[soundClipIndex]);
            Destroy(gameObject,3);
        }
        else if (other.gameObject.CompareTag("Sugar"))
        {
            Destroy(other.gameObject);
            orderHolder?.GetOrder().AddSuger();
        }

    }
}
