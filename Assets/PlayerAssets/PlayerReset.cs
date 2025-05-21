using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody rb;

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter: " + collision.gameObject.name);  // ★ 接触したオブジェクト名を表示

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemyと衝突しました。初期位置に戻します。");
            ResetToStart();
        }
        else
        {
            Debug.Log("Enemyタグではありません（タグ: " + collision.gameObject.tag + "）");
        }
    }

    void ResetToStart()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;
        Debug.Log("初期位置に戻しました。");
    }
}
