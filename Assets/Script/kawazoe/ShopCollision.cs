using UnityEngine;

public class ShopCollision : MonoBehaviour
{
    public AudioClip collisionSound1; // 効果音を指定
    public AudioClip collisionSound2; // 効果音を指定
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

    private void PlayCollisionSounds()
    {
        // 効果音をランダムに再生する
        AudioClip clipToPlay = Random.value > 0.5f ? collisionSound1 : collisionSound2;
        audioSource.PlayOneShot(clipToPlay);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            PlayCollisionSounds();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Human"))
        {
            PlayCollisionSounds();
        }
    }
}
