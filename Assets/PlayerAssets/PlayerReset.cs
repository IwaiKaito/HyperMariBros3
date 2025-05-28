using UnityEngine;
using TMPro;  // TextMeshProを使う場合

public class PlayerReset : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody rb;

    public TextMeshProUGUI messageText; // ← 追加：UIへの参照

    void Start()
    {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();

        if (messageText != null)
            messageText.text = "";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ResetToStart();
        }
    }

    void ResetToStart()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initialPosition;

        if (messageText != null)
        {
            messageText.text = "Game Over!";
            Invoke(nameof(ClearMessage), 2f); // 2秒後に消す
        }
    }

    void ClearMessage()
    {
        if (messageText != null)
            messageText.text = "";
    }
}
