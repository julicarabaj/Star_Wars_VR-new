using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivation : MonoBehaviour
{
    public float tiempoDesactivacion = 30f;

    private void Start()
    {
        // Invoca el método DesactivarEnemigo después de tiempoDesactivacion segundos
        Invoke("DesactivarEnemigo", tiempoDesactivacion);
    }

    private void DesactivarEnemigo()
    {
        // Desactiva el GameObject del enemigo
        gameObject.SetActive(false);
    }
}

