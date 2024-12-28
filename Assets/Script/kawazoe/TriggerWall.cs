using UnityEngine;

public class TriggerWall : MonoBehaviour
{
    // トリガーに触れたときに呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // ヒューマンタグのオブジェクトに反応する
        if (other.CompareTag("Human"))
        {
            Destroy(other.gameObject);
        }
    }
}
