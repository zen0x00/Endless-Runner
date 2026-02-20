using UnityEngine;
using UnityEngine.AI;
public class SharkPatrol : Enemy
{
    public float patrolRadius = 20f;
    public float AttackRange = 3f;
    public float attackCooldown = 2f;
    private float lastAttackTime = 0f;

    private bool isAttacking = false;

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
    float distance = Vector3.Distance(player.position, transform.position);

    
    if (distance <= detectionRange)
    {
        isChasing = true;
    }
    else
    {
        isChasing = false;
    }


    if (!isChasing)
    {
        isAttacking = false;
        agent.isStopped = false;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            Patrol();
        }

        return;
    }

   
    if (distance <= AttackRange)
    {
        agent.isStopped = true;
        isAttacking = true;

      
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            Attack();
        }
    }
    else
    {
       
        isAttacking = false;
        agent.isStopped = false;
        agent.SetDestination(player.position);
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

    public void Attack()
    {
        lastAttackTime  = Time.time;

        playerhealth playerhealth = player.GetComponent<playerhealth>();
        
        playerhealth.Danger();
    }
}
