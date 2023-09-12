using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasers : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject ExplosionEffect;
    void Start()
    {
        //Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += transform.forward * speed;
    }

    void OnCollisionEnter(Collision col)
    {
        //Instantiate(ExplosionEffect, transform.position, transform.rotation);
        if (col.gameObject.CompareTag("Lightsaber"))
        {
            Destroy(gameObject);
        }   
      
    }
}