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
        if (col.gameObject.name == "Lightsaber")
        {
            Instantiate(ExplosionEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Debug.Log("me toco ;)");
            //no anda :(
        }   
      
    }
}