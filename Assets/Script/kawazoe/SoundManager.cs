using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] soundEffects; // 効果音を格納する配列
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 効果音を再生するメソッド
    public void PlaySound(int index)
    {
        if (index >= 0 && index < soundEffects.Length)
        {
            audioSource.PlayOneShot(soundEffects[index]);
        }
        else
        {
            Debug.LogWarning("指定された効果音インデックスが無効です。");
        }
    }
}
