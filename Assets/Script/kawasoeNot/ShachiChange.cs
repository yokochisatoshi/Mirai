using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShachiChange : MonoBehaviour
{
    // 切り替える位置を指定
    public Vector3 positionA = new Vector3(-100, 0, -100); // 初期位置
    public Vector3 positionB = new Vector3(22f, -0.2f, 5f); // 切り替え先

    // 現在の状態を管理
    private bool isAtPositionA = true;

    void Update()
    {
        // エンターキーが押されたとき
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (isAtPositionA)
            {
                transform.position = positionB; // 位置Bに移動
            }
            else
            {
                transform.position = positionA; // 位置Aに移動
            }

            // 状態を反転
            isAtPositionA = !isAtPositionA;
        }
    }
}
