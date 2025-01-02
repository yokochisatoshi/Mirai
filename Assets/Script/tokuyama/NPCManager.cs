using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCManager : MonoBehaviour
{
    public GameObject NPC_00;
    private int nInterval = 60;  //ステージなどによってPopのインターバルは変わるのでそれ用
    private int nCntInterval = 0;  //インターバルカウント用




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //地面の手前の端と奥の端の座標 X座標です
        int StartPos = 0;
        //int EndPos = 100;


        if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //モーニング
             (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //昼
             (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //夜
        {
            nInterval = 15;
        }
        else
        {
            nInterval = 60;
        }


        nCntInterval++;
        //ステージによって場合分け
        switch (PlayerData.Instance.nCurrentStage)
        {
            case 0:

                // 川添いじった（human処理が重くデバックが思ったようにできないためコメントアウトして、生成をやめた）

                //if (nCntInterval > nInterval)
                //{
                //    nCntInterval = 0;
                //    Instantiate(NPC_00, new Vector3(StartPos, 0, Random.Range(-1.0f, 11.0f)), Quaternion.Euler(0, 90, 0));

                //}
                break;

        }

    }
}