using UnityEngine;
using UnityEngine.AI;

public class PatrolOnlyAI : MonoBehaviour
{
    public Transform[] patrolPoints;  // 巡回ポイント（複数必要）
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    void Update()
    {
        if (patrolPoints.Length == 0) return;

        // 現在の目標地点に近づいたら、次のポイントへ
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
}
