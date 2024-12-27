using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // トリガーに触れたときに呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // ヒューマンタグのオブジェクトに反応する
        if (other.CompareTag("Human"))
        {
            // ヒューマンオブジェクトを非アクティブにする（見えなくする）
            other.gameObject.SetActive(false);

            // もしくは完全に破壊する場合
            // Destroy(other.gameObject);
        }
    }
}
