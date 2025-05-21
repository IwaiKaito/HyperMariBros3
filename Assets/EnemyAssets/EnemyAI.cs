using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;           // プレイヤーの位置
    public float chaseDistance = 10f;  // 追いかける範囲

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);

        if (distance < chaseDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            agent.ResetPath(); // 範囲外なら止まる
        }
    }
}
