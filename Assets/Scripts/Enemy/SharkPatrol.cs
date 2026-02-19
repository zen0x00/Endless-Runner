using UnityEngine;
using UnityEngine.AI;
public class SharkPatrol : Enemy
{
    public float patrolRadius = 20f;
    private NavMeshAgent agent;
    private Vector3 startPosition;
    public float detectionRange = 15f;
    public Transform player;
    private bool isChasing = false;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        Patrol();
    }

    void Update()
    {
        float distance = Vector3.Distance(player.position,transform.position);
                
        if (distance <= detectionRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (isChasing)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                Patrol();
            }
        }

    }

    void Patrol()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += startPosition;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, 1))
        {
            agent.SetDestination(hit.position);
        }
    }
}
