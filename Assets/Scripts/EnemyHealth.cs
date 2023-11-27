using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int golpesRecibidos = 0;
    private bool isDead = false;
    [SerializeField] Animator animator;
    private EnemyController enemycontroller; // Mover la declaración aquí
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        enemycontroller = FindObjectOfType<EnemyController>(); // Asigna la referencia aquí
        Debug.Log("Enemigos muertos: " + enemycontroller.clonesMuertos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isDead) return;

        if (collision.gameObject.tag == "Lightsaber")
        {
            golpesRecibidos++;
            if (golpesRecibidos >= 2)
            {
                Debug.Log("Muerte");
                animator.SetBool("Death", true);
                StartCoroutine(DestroyEnemyAfterAnimation());
            }
        }
    }
    private IEnumerator DestroyEnemyAfterAnimation()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
        isDead = true;
        enemycontroller.clonesMuertos++;
    }
}