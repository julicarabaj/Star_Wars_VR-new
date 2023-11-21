using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float lifeTime;
    public GameObject ExplosionEffect;
    private AudioSource source;
    public AudioClip clash;
    public Vector3 laserVelocity;
    void Start()
    {
      Destroy(gameObject, lifeTime);
      source = gameObject.AddComponent<AudioSource>();
      source.spatialBlend = 1;
      source.volume = 8f;
      rb = GetComponent<Rigidbody>();
      rb.velocity = laserVelocity;
    }

    void Update()
    {
        // transform.position += transform.forward * speed * Time.deltaTime;
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Lightsaber"))
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("�Me toco!");
            if (source != null && source.enabled)
            {
                source.PlayOneShot(clash);
            }
        }
    }
}