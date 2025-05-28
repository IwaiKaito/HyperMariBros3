using UnityEngine;
using UnityEngine.AI;

public class PatrolAndChaseAI : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 8f;

    public Transform[] patrolPoints; // 巡回ポイント（2個以上）
    private int currentPatrolIndex = 0;

    private NavMeshAgent agent;

    private enum State { Patrolling, Chasing }
    private State state = State.Patrolling;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[0].position);
        }
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < chaseDistance)
        {
            state = State.Chasing;
        }
        else
        {
            state = State.Patrolling;
        }

        switch (state)
        {
            case State.Patrolling:
                Patrol();
                break;
            case State.Chasing:
                ChasePlayer();
                break;
        }
    }

    void Patrol()
    {
        if (patrolPoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        }
    }

    void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
}
