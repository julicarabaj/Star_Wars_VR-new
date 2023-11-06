using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivation : MonoBehaviour
{
    public float tiempoDesactivacion = 30f;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(DesactivarEnemigoConAnimacion());
    }

    private IEnumerator DesactivarEnemigoConAnimacion()
    {
        if (animator != null)
        {
            animator.SetTrigger("ActivarAnimacion"); 
        }
        yield return new WaitForSeconds(tiempoDesactivacion);
        gameObject.SetActive(false);
    }
}
