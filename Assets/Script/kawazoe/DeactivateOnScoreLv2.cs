using UnityEngine;
using UnityEngine.SceneManagement;

public class DeactivateOnScoreLv2 : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // スコアが目標値に達したらオブジェクトを非アクティブ化する
        if (PlayerData.Instance.nMoney >= 1000)
        {
            gameObject.SetActive(false);
        }
    }
}
