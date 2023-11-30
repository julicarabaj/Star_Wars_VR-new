using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{  
    [SerializeField] int colisiones; 
    [SerializeField] Animator animator;
    private bool isDead = false;
    private int golpesRecibidos = 0;
    public EnemyController enemycontroller; // Mover la declaración aquí
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
            if (golpesRecibidos >= colisiones)
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