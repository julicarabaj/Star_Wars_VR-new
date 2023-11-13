using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClonMoovement : MonoBehaviour
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
        // Buscar todos los objetos con el tag "Target" y agregarlos a la lista de destinations
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject targetObject in targetObjects)
        {
            destinations.Add(targetObject.transform);
        }

        // Establecer la primera destination
        SetNextDestination();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Llamar a EnemyPath en cada frame
        EnemyPath();
        // Puedes realizar otras acciones en Update si es necesario
    }

    void SetNextDestination()
    {
        // Establecer la siguiente destination en la lista
        navMeshAgent.destination = destinations[currentDestinationIndex].position;

        // Incrementar el índice para la próxima destination
        currentDestinationIndex = (currentDestinationIndex + 1) % destinations.Count;
    }

    public void EnemyPath()
    {
        // Verificar si el agente ha alcanzado la destination actual
        if (navMeshAgent.remainingDistance <= distanceToFollowPath)
        {
            // Establecer la siguiente destination cuando se alcanza la actual
            SetNextDestination();
        }
    }
}
