using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemigo;  // Asigna el GameObject del enemigo en el Editor de Unity
    public float tiempoActivacion = 35f;
    bool enemigoActivado;

    //private bool enemigoActivado = false;

    private void Start()
    {
        enemigo.SetActive(false);
        Invoke("ActivarEnemigo", tiempoActivacion);
    }

    private void ActivarEnemigo()
    {
        if (!enemigoActivado)
        {
            enemigo.SetActive(true);
            enemigoActivado = true;
        }
    }
}

