using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Queue<GameObject> effectPool = new Queue<GameObject>();
    public GameObject effectPrefab;
    public int poolSize = 10;

    private void Start()
    {
        // プールを初期化
        for (int i = 0; i < poolSize; i++)
        {
            GameObject effect = Instantiate(effectPrefab);
            effect.SetActive(false);
            effectPool.Enqueue(effect);
        }
    }

    // エフェクトを取得して表示
    public GameObject GetEffect(Vector3 position, Quaternion rotation)
    {
        GameObject effect;

        // プールにエフェクトがあれば、それを使用
        if (effectPool.Count > 0)
        {
            effect = effectPool.Dequeue();
        }
        else
        {
            // プールが空の場合、新しくエフェクトをインスタンス化
            effect = Instantiate(effectPrefab, position, rotation);
        }

        // 位置と回転を設定
        effect.transform.position = position;
        effect.transform.rotation = rotation;
        effect.SetActive(true);  // エフェクトを表示

        return effect;
    }

    // 使用後、エフェクトをプールに戻す
    public void ReturnEffect(GameObject effect)
    {
        effect.SetActive(false);  // エフェクトを非表示にする
        effectPool.Enqueue(effect); // プールに戻す
    }
}
