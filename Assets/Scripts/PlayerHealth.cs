using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int disparosRecibidos = 0;
    private AudioSource source;
    public AudioClip hit; //este es el sonido

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 3f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            disparosRecibidos++;
            source.PlayOneShot(hit);
            Debug.Log("Sonido!");
            //if (hit != null && source != null)
          //  {
            //    source.PlayOneShot(hit);
            //}
            if (disparosRecibidos >= 5)
            {
                 //moris
            }
        }
    }
}
