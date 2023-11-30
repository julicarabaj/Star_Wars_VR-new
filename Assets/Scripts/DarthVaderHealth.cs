using System.Collections;
using UnityEngine;

public class DarthVaderHealth : MonoBehaviour
{
    [SerializeField] int colisiones;
    private bool isDead = false;
    private int golpesRecibidos = 0;
    public EnemyController enemycontroller;

    private void Start()
    {
        enemycontroller = FindObjectOfType<EnemyController>(); 
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
                isDead = true;
                Destroy(gameObject);
            }
        }
    }
  
}