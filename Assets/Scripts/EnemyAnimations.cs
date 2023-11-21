using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;
    private int muertes = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float velocidadActual = GetComponent<Rigidbody>().velocity.magnitude;
        animator.SetFloat("Speed", velocidadActual);

        if (muertes >= 2)
        {
            ActivarAnimacionMuerte();
        }
    }

    private void ActivarAnimacionMuerte()
    {
        // Triggerear la animación de "muerte"
        animator.SetTrigger("Death");
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Lightsaber"))
        {
            GolpeadoPorLightsaber();
        }
    }

    public void GolpeadoPorLightsaber()
    {
        muertes++;
        animator.SetInteger("Muertes", muertes);
        animator.SetTrigger("Muerte");
    }
}