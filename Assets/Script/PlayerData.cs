using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int money = 777;  // 初期のお金

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

    // お金を増やすメソッド
    public void AddMoney(int amount)
    {
        money += amount;
        Debug.Log("Current Money: " + money);  
    }
}
