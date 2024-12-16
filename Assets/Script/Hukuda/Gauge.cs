using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Gauge : MonoBehaviour
{
    private GameObject parent;

    
    EnemyShop enemyShop;
    
    [SerializeField] Texture UpGauge1;
    [SerializeField] Texture UpGauge2;
    [SerializeField] Texture UpGauge3;
    [SerializeField] Texture UpGauge4;
    [SerializeField] Texture UpGauge5;
    [SerializeField] Texture UpGauge6;
    [SerializeField] Texture UpGauge7;
    [SerializeField] Texture UpGauge8;
    [SerializeField] Texture UpGauge9;
    [SerializeField] Texture UpGauge10;
    [SerializeField] Texture UpGauge11;

    Texture texture;
    Material material;

    float dashPoint;
    void Start()
    {
        parent = this.gameObject.transform.parent.gameObject;
        enemyShop = parent.GetComponent<EnemyShop>();
        dashPoint = enemyShop.cooltime;
        

        //マテリアル取得
        material = this.GetComponent<MeshRenderer>().material;
        //テクスチャ取得
        texture = material.GetTexture("_MainTex");
    }

    void Update()
    {
        float GaugePoint = 0;

        //Hissatu.value = enemyShop.count;
     if(dashPoint < enemyShop.count)
     {
        dashPoint++;
     }

     material = this.GetComponent<MeshRenderer>().material;
        GaugePoint = (float)(enemyShop.count) / (float)(enemyShop.cooltime) * 100;
        if (GaugePoint >= 0 && GaugePoint <= 9)
        {
            material.SetTexture("_MainTex", UpGauge1);
        }
        else if (GaugePoint >= 10 && GaugePoint <= 19)
        {
            material.SetTexture("_MainTex", UpGauge2);
        }
        else if (GaugePoint >= 20 && GaugePoint <= 29)
        {
            material.SetTexture("_MainTex", UpGauge3);
        }
        else if (GaugePoint >= 30 && GaugePoint <= 39)
        {
            material.SetTexture("_MainTex", UpGauge4);
        }
        else if (GaugePoint >= 40 && GaugePoint <= 49)
        {
            material.SetTexture("_MainTex", UpGauge5);
        }
        else if (GaugePoint >= 50 && GaugePoint <= 59)
        {
            material.SetTexture("_MainTex", UpGauge6);
        }
        else if (GaugePoint >= 60 && GaugePoint <= 69)
        {
            material.SetTexture("_MainTex", UpGauge7);
        }
        else if (GaugePoint >= 70 && GaugePoint <= 79)
        {
            material.SetTexture("_MainTex", UpGauge8);
        }
        else if (GaugePoint >= 80 && GaugePoint <= 89)
        {
            material.SetTexture("_MainTex", UpGauge9);
        }
        else if (GaugePoint >= 90 && GaugePoint <= 99)
        {
            material.SetTexture("_MainTex", UpGauge10);
        }
        else if(GaugePoint == 100)
        {
            material.SetTexture("_MsinTex", UpGauge11);
        }
    }
}
