using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemigo;
    public Transform spawnPoint;
    public float tiempoEntreSpawn = 10f;
    private int cantidadMaxima = 3; 
    private int cantidadActual = 0;
    public GameObject Vader;
    private AudioSource source;
    public AudioClip marcha;
    EnemyHealth enemyhealth;
    public int clonesMuertos;
    void Start()
    {
        enemyhealth = GetComponent<EnemyHealth>();
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 1;
        source.volume = 3f;
        InvokeRepeating("spawnPrefab", 5f, tiempoEntreSpawn);
    }
    void Update()
    {
    }

    void spawnPrefab()
    {
        //revisar de que cuando hago el clonesDestruidos++ tambien suba la cantidad en el clonesMuertos
        if (clonesMuertos <= 5)
        {
            if (cantidadActual < cantidadMaxima)
            {
                Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
                cantidadActual++;
                Debug.Log("Spawn Enemy");
            }
        }
        else
        {
            Debug.Log("Spawn Vader");
            CancelInvoke("spawnPrefab");
            SpawnVader();
        }
        //quiza hay que poner un else para que no los siga spawniando
    }
   public void SpawnVader()
    {
        
            //spawn darth vader
            Instantiate(Vader, spawnPoint.position, spawnPoint.rotation);
            // source.PlayOneShot(marcha);
            if (marcha != null)
            {
                AudioSource audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.clip = marcha;
                audioSource.Play();

                // Puedes ajustar otros parámetros según sea necesario, como el volumen, el bucle, etc.
                // audioSource.volume = 0.5f;
                // audioSource.loop = true;

                // Destruir el AudioSource después de que termine de reproducir
                Destroy(audioSource, marcha.length);
            }
            else
            {
                Debug.LogError("AudioClip de la marcha imperial no asignado.");
            }
        
    }
}
