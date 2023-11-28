using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallActivation : MonoBehaviour
{
    private float tiempoDesactivacion = 5f;
    [SerializeField] Animator animator;
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent navMeshAgent;
    public Transform[] destinations; //Array para los puntos target del enemy
    public float distanceToFollowPath = 2;
    private int i = 0;
    private float distancePlayer;
    public float distanceToFollow = 5;

    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    private void Start()
    {
        navMeshAgent.destination = destinations[0].transform.position; //si se quiere un target especifico sin moverse en el start esta bien
        player = GameObject.FindGameObjectWithTag("Player");
       animator = GetComponent<Animator>();
        StartCoroutine(DesactivarEnemigoConAnimacion());
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
    private IEnumerator DesactivarEnemigoConAnimacion()
    {
        //if (animator != null)
        //{
        //    animator.SetTrigger("ActivarAnimacion");
        //}
        yield return new WaitForSeconds(tiempoDesactivacion);
        gameObject.SetActive(false);
    }
}
