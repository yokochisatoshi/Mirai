using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject buildingPrefab;       // 建設する建物のPrefab
    //public GameObject gaugeObject;        　// 建築後に表示するゲージオブジェクト
    public GameObject rangeObject;          // 建築後に表示する範囲オブジェクト
    private bool isConstructed = false;     // 建物が建設済みかどうか

    void Start()
    {
        if (/*gaugeObject != null &&*/ rangeObject != null)
        {
            //gaugeObject.SetActive(false);
            rangeObject.SetActive(false);
        }
    }

    void Update()
    {
        // scoreが一定に達した場合
        if (PlayerData.Instance.nMoney >= 1000 && !isConstructed)
        {
            // z座標を元に角度を計算
            float zPosition = transform.position.z;
            float rotationY = CalculateRotationAngle(zPosition);

            // 建物を生成
            Instantiate(buildingPrefab, transform.position, Quaternion.Euler(0, rotationY, 0));

            // 表示オブジェクトを有効化
            if (/*gaugeObject != null &&*/ rangeObject != null)
            {
                //gaugeObject.SetActive(true);
                rangeObject.SetActive(true);
            }

            //Destroy(gameObject);

            isConstructed = true;

            //ConstructBuilding();
            Debug.Log("建築します！");
        }

    }

    private void ConstructBuilding()
    {
        if (buildingPrefab != null)
        {
            // 現在の空き地の位置に建物を設置
            Instantiate(buildingPrefab, transform.position, Quaternion.identity);

            Debug.Log("!!!!!");
            // 空き地のGameObjectを削除
            Destroy(gameObject);

            isConstructed = true;
        }
    }

    // z座標に応じた回転角度を計算する関数
    private float CalculateRotationAngle(float zPosition)
    {
        // 敵の店か自店かで角度を調整する
        if (CompareTag("EnemyStore"))
        {
            // 例えば、zが正の値で右向き、負の値で左向きにする場合
            if (zPosition > 0)
            {
                Debug.Log("右向きます！");
                return 180f; // 右向き
            }
            else
            {
                Debug.Log("左向きます！");
                return 0f; // 正面向き
            }
        }
        else
        {
            Debug.Log("自店です");
            // 例えば、zが正の値で右向き、負の値で左向きにする場合
            if (zPosition > 0)
            {
                Debug.Log("右向きます！");
                return 0f; // 右向き
            }
            else
            {
                Debug.Log("左向きます！");
                return 180f; // 正面向き
            }
        }
    }
}