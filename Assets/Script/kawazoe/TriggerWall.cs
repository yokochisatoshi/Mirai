using UnityEngine;


public class TriggerWall : MonoBehaviour
{
    NPCManager NPCManagerSc;

    private void Start()
    {
        NPCManagerSc = GameObject.Find("ManageNPC").GetComponent<NPCManager>();
    }

    // トリガーに触れたときに呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // ヒューマンタグのオブジェクトに反応する
        if (other.CompareTag("Human"))
        {
            NPCManagerSc.DestroyList(other.gameObject);
            Destroy(other.gameObject);
        }
    }
}
