using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private int disparosRecibidos = 0;
    private AudioSource source;
    public AudioClip hit; //este es el sonido
    public Image barraDeVida;
    public float vidaActual = 100;
    public float vidaMaxima = 100;

    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 3f;
    }
    private void Update()
    {
        barraDeVida.fillAmount = vidaActual / vidaMaxima;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            disparosRecibidos++;
            source.PlayOneShot(hit);
            Debug.Log("Sonido!");
            vidaActual -= 10;
           // barraDeVida.fillAmount = vidaActual / vidaMaxima;
            //if (hit != null && source != null)
            //  {
            //    source.PlayOneShot(hit);
            //}
            if (disparosRecibidos >= 10)
            {
                 //moris
            }
        }
    }
}
