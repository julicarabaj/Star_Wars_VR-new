using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int golpesRecibidos = 0;
    private bool isDead = false;
    private Animator animator;
    public int clonesDestruidos = 0;
    private EnemyController enemyController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        // Inicia la animación de caminata
        animator.SetBool("IsWalking", true);
        enemyController = GetComponent<EnemyController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.tag == "Lightsaber")
        {
            golpesRecibidos++;
            if (golpesRecibidos >= 3)
            {
                // Detiene la animación de caminata
                animator.SetBool("IsWalking", false);
                animator.SetTrigger("Death");
                StartCoroutine(DestroyEnemyAfterAnimation());
            }
        }
    }

    private IEnumerator DestroyEnemyAfterAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("Has ganado. Le pegaste 3 veces a Darth Vader.");
        Destroy(gameObject);
        isDead = true;
        clonesDestruidos++;
        if(clonesDestruidos > 5)
        {
            enemyController.SpawnVader();
        }
    }
}
