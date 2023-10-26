using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxhealth;
    public float health;
    public bool isAlive = true;
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if(isAlive)
        {
            health -= damage;
            if (health <= 0)
            {
                //murio
                death();
            }
            else
            {
                //animacion de recibir daño
            }
        }
    }
    void death()
    {
        //todos los elementos que se disparan cuando la salud llega a 0
        Debug.Log("Death");
        //animacion muerte
    }
}
