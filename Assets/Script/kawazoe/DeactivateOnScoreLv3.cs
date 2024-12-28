using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv3 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // スコアが目標値に達したらオブジェクトを非アクティブ化する
        if (PlayerData.Instance.nMoney >= 1200)
        {
            gameObject.SetActive(false);
        }
    }
}
