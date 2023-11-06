using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMoovment : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations; //Array para los puntos target del enemy
    public float distanceToFollowPath = 2;
    private int i = 0;
    private float distancePlayer;
    public float distanceToFollow = 5;
    public GameObject NPCPrefab;
    public Transform target;
    float tiempoLimite = 5;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position; //si se quiere un target especifico sin moverse en el start esta bien
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);
        EnemyPath();
        if (tiempoLimite < Time.time)
        {
            Spawn();
            tiempoLimite += 5;
        }
    }
    public void EnemyPath()
    {
        navMeshAgent.destination = destinations[i].position;

        if (Vector3.Distance(transform.position, destinations[i].position) <= distanceToFollowPath)
        {
            if (destinations[i] != destinations[destinations.Length - 1])
            {
                i++;
            }
            else
            {
                i = 0;
            }

        }

    }
    void Spawn()
    {
        int teleport = Random.Range(0, 4);
        Instantiate(NPCPrefab, destinations[teleport].position, destinations[teleport].rotation);
        //GameObject clon = Instantiate(NPCPrefab, transform.position, Quaternion.identity);
        //clon.transform.destination = target.transform;
    }
}