using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int golpesRecibidos = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Lightsaber")
        {
            golpesRecibidos++;
            if (golpesRecibidos >= 5)
            {
                // El jugador gana el juego
                Debug.Log("Has ganado. Le pegaste 5 veces a Darth Vader.");
            }
        }
    }

}
