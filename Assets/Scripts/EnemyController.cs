using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemigo;  // Asigna el GameObject del enemigo en el Editor de Unity
    public float tiempoActivacion = 0f;
    bool enemigoActivado;
    public Transform EnemySpawn;

    //private bool enemigoActivado = false;

    private void Start()
    {
        enemigo.SetActive(true);
        Invoke("ActivarEnemigo", tiempoActivacion);
    }

    private void ActivarEnemigo()
    {

        Instantiate(enemigo, EnemySpawn.position, EnemySpawn.rotation);
    }
}