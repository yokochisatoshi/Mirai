using UnityEngine;

public class ScaleOnScore : MonoBehaviour
{
    public float targetScore = 1000f;    // スケールを変更するスコアの閾値
    public float nextScore = 1000f;
    public Vector3 scaleIncrease = new Vector3(0.4f, 0.4f, 0f); // 現在のスケールに加算する値

    private int Level = 1;

    private void Update()
    {
        // スコアが一定値に達したらスケールを増加
        if (PlayerData.Instance.nScore >= targetScore && Level < 3)
        {
            // 現在のスケールに加算
            transform.localScale += scaleIncrease;

            // 次のレベルに合ったスコア値に変更する
            targetScore += nextScore;

            Level++;

            if (Level == 3)
            {
                // 位置の変更
                transform.position = new Vector3(transform.position.x, transform.position.y + 70f, transform.position.z);
            }

        }
    }
}