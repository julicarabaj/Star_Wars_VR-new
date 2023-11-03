using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int golpesRecibidos = 0;
    private bool isDead = false;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return; // Si el enemigo ya est� muerto, no procesar m�s colisiones.

        if (collision.gameObject.tag == "Lightsaber")
        {
            golpesRecibidos++;
            if (golpesRecibidos >= 10)
            {
                // Ejecutar la animaci�n de muerte si el enemigo ha recibido suficientes golpes.
                animator.SetTrigger("Death");

                // Esperar a que la animaci�n de muerte termine antes de destruir el objeto del enemigo.
                StartCoroutine(DestroyEnemyAfterAnimation());
            }
        }
    }

    private IEnumerator DestroyEnemyAfterAnimation()
    {
        // Ajusta el tiempo de espera seg�n la duraci�n de tu animaci�n de muerte.
        yield return new WaitForSeconds(2.0f); // Espera 2 segundos (ajusta el valor seg�n tu animaci�n).

        // El jugador gana el juego
        Debug.Log("Has ganado. Le pegaste 10 veces a Darth Vader.");

        // Destruye el objeto del enemigo.
        Destroy(gameObject);

        isDead = true; // Marcar al enemigo como muerto para evitar procesar m�s colisiones.
    }
}
