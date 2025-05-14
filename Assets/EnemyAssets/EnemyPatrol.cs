using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;       // パトロール地点
    private int currentPointIndex = 0;
    private NavMeshAgent agent;

    public Transform player;               // プレイヤーのTransform
    public float chaseDistance = 10f;      // 追跡開始距離

    private bool isChasing = false;

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
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        // プレイヤーが近いときは追跡モード
        if (distanceToPlayer < chaseDistance)
        {
            isChasing = true;
            agent.SetDestination(player.position);
        }
        else
        {
            if (isChasing)
            {
                // プレイヤーから離れたらパトロールに戻す
                isChasing = false;
                agent.SetDestination(patrolPoints[currentPointIndex].position);
            }

            // 通常のパトロール処理
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
                agent.SetDestination(patrolPoints[currentPointIndex].position);
            }
        }
    }
}
