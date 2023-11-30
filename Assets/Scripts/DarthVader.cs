using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DarthVader : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent navMeshAgent;
    public List<Transform> destinations = new List<Transform>();
    public float distanceToFollowPath = 2;
    private int currentDestinationIndex = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Objetivo");
        foreach (GameObject targetObject in targetObjects)
        {
            destinations.Add(targetObject.transform);
        }
        SetNextDestination();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        EnemyPath();
    }

    void SetNextDestination()
    {
        navMeshAgent.destination = destinations[currentDestinationIndex].position;
        currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Count;
    }

    public void EnemyPath()
    {
        if (navMeshAgent.remainingDistance <= distanceToFollowPath)
        {
            SetNextDestination();
        }
    }
}
