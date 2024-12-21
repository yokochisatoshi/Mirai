using UnityEngine;

public class ShopCollision : MonoBehaviour
{
    public AudioClip collisionSound; // 効果音を指定
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource コンポーネントを取得または追加
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // 衝突時に呼び出される
    private void OnCollisionEnter(Collision collision)
    {
        // Playerタグのオブジェクトと衝突した場合
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }

    // トリガーを使用する場合
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(collisionSound);
        }
    }
}
