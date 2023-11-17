using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject ExplosionEffect;
    private AudioSource source;
    public AudioClip clash;
    void Start()
    {
      Destroy(gameObject, lifeTime);
      source = gameObject.AddComponent<AudioSource>();
      source.spatialBlend = 1;
      source.volume = 8f;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Lightsaber"))
        {
            //Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("¡Me toco!");
            if (source != null && source.enabled)
            {
                source.PlayOneShot(clash);
            }
        }
    }
}