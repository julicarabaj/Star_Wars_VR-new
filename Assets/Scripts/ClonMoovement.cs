using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ClonMoovement : MonoBehaviour
{
 
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public Transform[] destinations; //Array para los puntos target del enemy
    public float distanceToFollowPath = 2;
    private int i = 0;
    private float distancePlayer;
    public float distanceToFollow = 5;
    public Transform target;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        destinations = FindObjectOfType<EnemyPathScript>().enemyDestinations;
        navMeshAgent.destination = destinations[0].transform.position; //si se quiere un target especifico sin moverse en el start esta bien
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        distancePlayer = Vector3.Distance(transform.position, player.transform.position);
        EnemyPath();        
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
}