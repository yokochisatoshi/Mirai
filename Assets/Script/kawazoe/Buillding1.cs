using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Billding1 : MonoBehaviour
{
    public GameObject buildingPrefab;       // 建設する建物のPrefab
    private bool isConstructed = false;     // 建物が建設済みかどうか
    private int Score = PlayerData.Instance.nScore;


    void Start()
    {

    }

    void Update()
    {
        // scoreが一定に達した場合
        if (PlayerData.Instance.nMoney > 1000 && !isConstructed)
        {
            ConstructBuilding();
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

}