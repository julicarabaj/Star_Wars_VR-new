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
        if (isDead) return; // Si el enemigo ya está muerto, no procesar más colisiones.

        if (collision.gameObject.tag == "Lightsaber")
        {
            golpesRecibidos++;
            if (golpesRecibidos >= 10)
            {
                // Ejecutar la animación de muerte si el enemigo ha recibido suficientes golpes.
                animator.SetTrigger("Death");

                // Esperar a que la animación de muerte termine antes de destruir el objeto del enemigo.
                StartCoroutine(DestroyEnemyAfterAnimation());
            }
        }
    }

    private IEnumerator DestroyEnemyAfterAnimation()
    {
        // Ajusta el tiempo de espera según la duración de tu animación de muerte.
        yield return new WaitForSeconds(2.0f); // Espera 2 segundos (ajusta el valor según tu animación).

        // El jugador gana el juego
        Debug.Log("Has ganado. Le pegaste 10 veces a Darth Vader.");

        // Destruye el objeto del enemigo.
        Destroy(gameObject);

        isDead = true; // Marcar al enemigo como muerto para evitar procesar más colisiones.
    }
}
