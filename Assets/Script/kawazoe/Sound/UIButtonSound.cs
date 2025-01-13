using UnityEngine;

public class UIButtonSound : MonoBehaviour
{
    public AudioClip clickSound;  // 再生するサウンド
    private AudioSource audioSource;

    void Start()
    {
        // AudioSourceコンポーネントを取得または追加
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // 必要ならサウンドの設定を変更
        audioSource.playOnAwake = false; // 再生はスクリプトから行う
        audioSource.loop = false;       // ループ再生しない
    }

    // ボタンがクリックされたときに呼ばれる関数
    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // サウンドを再生
        }
    }
}
