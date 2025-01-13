using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;  // シングルトンインスタンス
    public AudioSource audioSource;      // AudioSource コンポーネント
    public AudioClip[] soundClips;      // 再生可能なサウンドのリスト

    void Awake()
    {
        // シングルトンパターン: 1つのインスタンスのみ
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // シーン遷移後も破棄しない
        }
        else
        {
            Destroy(gameObject);  // 他のインスタンスが存在する場合、このオブジェクトを削除
        }

        // AudioSource コンポーネントを取得または追加
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // AudioSource の設定
        audioSource.playOnAwake = false; // 初期化時に音を鳴らさない
        audioSource.loop = false;        // 音をループしない
    }

    /// <summary>
    /// サウンドを再生するメソッド
    /// </summary>
    /// <param name="clipName">再生するサウンドの名前</param>
    public void PlaySound(string clipName)
    {
        // サウンドを名前で検索
        AudioClip clip = GetSoundClipByName(clipName);
        if (clip != null)
        {
            audioSource.PlayOneShot(clip);  // サウンドを再生
        }
        else
        {
            Debug.LogWarning("SoundManager: サウンドが見つかりません: " + clipName);
        }
    }

    /// <summary>
    /// サウンドの名前からAudioClipを検索するヘルパーメソッド
    /// </summary>
    /// <param name="clipName">サウンドの名前</param>
    /// <returns>対応するAudioClip</returns>
    private AudioClip GetSoundClipByName(string clipName)
    {
        foreach (var clip in soundClips)
        {
            if (clip.name == clipName)
            {
                return clip;
            }
        }
        return null;
    }
}
