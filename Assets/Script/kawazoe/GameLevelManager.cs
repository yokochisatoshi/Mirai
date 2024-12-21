using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText; // TextMeshProUGUI コンポーネント
    public int score = 0;  // 現在のスコア
    public int level = 1;  // 現在のレベル
    public int maxLevel = 3; // 最大レベル
    public int[] scoreThresholds = { 0, 1000, 1200 }; // レベルアップの閾値

    void Start()
    {
        // 初期レベルを表示
        UpdateLevelUI();
        score = PlayerData.Instance.nMoney;
    }

    void Update()
    {
        // スコアのテスト用: キーを押すとスコアが増える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(100);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        // レベルをスコアに応じて更新
        CheckLevelUp();
    }

    void CheckLevelUp()
    {
        // 現在のスコアが閾値を超えたらレベルアップ
        for (int i = 0; i < scoreThresholds.Length; i++)
        {
            if (score >= scoreThresholds[i] && level < i + 1)
            {
                level = i + 1;
                if (level > maxLevel)
                {
                    level = maxLevel;
                }

                // レベルUIを更新
                UpdateLevelUI();
            }
        }
    }

    void UpdateLevelUI()
    {
        // UIテキストに現在のレベルを表示
        levelText.text = "Level: " + level;
    }
}
