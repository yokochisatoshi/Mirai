using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int nMoney = 777;  // 初期のお金
    public int nScore = 0;  // 初期のScore
    public int nTime = 0;    //時間管理  時計とか表示する時用
    //ステージ管理用   ステージ→発展度のこと
    public int nCurrentStage = 0;  
    public int nMaxStage = 3;

    void Awake()
    {
        // シングルトン
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        nTime++;
    }


    // お金を増やすメソッド
    public void AddMoney(int amount)
    {
        nMoney += amount;
       
    }

    public void AddScore(int amount)
    {
        nScore += amount;
    }
}
