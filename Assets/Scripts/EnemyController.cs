using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemigo;
    public Transform spawnPoint;
    public float tiempoEntreSpawn = 10f;
    public int cantidadMaxima = 3; 
    private int cantidadActual = 0; 

    void Start()
    {
        InvokeRepeating("spawnPrefab", 5f, tiempoEntreSpawn);
    }

    void spawnPrefab()
    {
        if (cantidadActual < cantidadMaxima)
        {
            Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
            cantidadActual++;
        }
        else
        {
            CancelInvoke("spawnPrefab");
        }
    }
}
