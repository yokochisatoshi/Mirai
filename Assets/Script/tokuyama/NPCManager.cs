using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//壁もあつかうぞおおおおおおおおおおおおおおおおおおおおおおおおおおお

public class NPCManager : MonoBehaviour
{
    public GameObject NPC_00;
    private int nInterval = 60;  //ステージなどによってPopのインターバルは変わるのでそれ用
    private int nCntInterval = 0;  //インターバルカウント用

    public GameObject Wall;
    private Vector3 Lv2WallPos;
    private Vector3 Lv3WallPos;

    // Start is called before the first frame update
    void Start()
    {
        Lv2WallPos = new Vector3(Wall.transform.position.x+35, Wall.transform.position.y, Wall.transform.position.z);
        Lv3WallPos = new Vector3(Wall.transform.position.x+70, Wall.transform.position.y, Wall.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //地面の手前の端と奥の端の座標 X座標です
        int StartPos = 0;
        float EndPos = Wall.transform.position.x - 1.0f;


        if ((PlayerData.Instance.nTime >= 60.0f && PlayerData.Instance.nTime <= 120.0f) ||        //モーニング
             (PlayerData.Instance.nTime >= 360.0f && PlayerData.Instance.nTime <= 420.0f) ||        //昼
             (PlayerData.Instance.nTime >= 720.0f && PlayerData.Instance.nTime <= 780.0f))          //夜
        {
            nInterval = 90;
        }
        else
        {
            nInterval = 180;
        }


        nCntInterval++;
        //ステージによって場合分け
        switch (PlayerData.Instance.nCurrentStage)
        {

        }
        //一時的
        if(PlayerData.Instance.nMoney>=1000)
        {
            Wall.transform.position =Lv2WallPos;
        }




        //一時的

        if (nCntInterval > nInterval)
        {
            nCntInterval = 0;
            int nRandom = Random.Range(0, 2);

            if(nRandom == 0)
            {
                Instantiate(NPC_00, new Vector3(StartPos, -1, Random.Range(-1.0f, 11.0f)), Quaternion.Euler(0, 90, 0));
            }
            else
            {
                Instantiate(NPC_00, new Vector3(EndPos, -1, Random.Range(-1.0f, 11.0f)), Quaternion.Euler(0, -90, 0));
            }
            

        }

    }
}