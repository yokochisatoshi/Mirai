using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float speed = 5f;      // 雲の移動速度
    private Vector3 initialPosition; // 雲の初期位置
    public float resetPositionX = -540f; // 再出現するX座標
    public float limitPositionX = 540f;  // 消える基準となるX座標

    void Start()
    {
        // 初期位置を記憶
        initialPosition = transform.position;
    }

    void Update()
    {
        // 雲を右方向に移動
        transform.position += Vector3.right * speed * Time.deltaTime;

        // 雲が指定されたX座標を超えたら左から再出現
        if (transform.position.x > limitPositionX)
        {
            Debug.Log("きました");
            transform.position = new Vector3(resetPositionX, initialPosition.y, initialPosition.z);
        }
    }
}
