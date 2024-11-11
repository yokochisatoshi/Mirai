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

    nCntInterval++;
        //ステージによって場合分け
        switch (PlayerData.Instance.nCurrentStage)
        {
            case 0:
                
                if(nCntInterval>nInterval)
                {
                    nCntInterval = 0;
                    Instantiate(NPC_00, new Vector3(StartPos, 0, Random.Range(0.0f, 10.0f)), Quaternion.Euler(0, 90, 0));
                  //  Debug.Log("tt");
                }


                break;

        }
        
    }
}
