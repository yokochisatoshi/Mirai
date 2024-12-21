using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;        川添いじった

public class EnemyShop : MonoBehaviour
{
    public int cooltime = 100;      // 必殺技のクールタイム
    public int count = 0;           // クールタイムのカウンタ
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 川添いじった　スペースキーを押したらcountをcooltime以上にする
        //count++;

        if (count > cooltime)
        { // cooltime分時間が経ったら
            count = 0;
            GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // 存在するHumanタグを持っているオブジェクトを配列に格納
            for (int i = 0; i < humanObjects.Length; i++)
            { // humanObjectsの要素分ループ
                human humanScript = humanObjects[i].GetComponent<human>();              // humanスクリプト取得
                if (humanScript.GetState() == (int)human.human_state.normal)
                { // 取得したhumanScriptの状態がnormalなら
                    humanScript.SetTargetEnemyStore(this.gameObject);                   // 取得したhumanスクリプトの向かう敵の店をこのオブジェクトにする
                    humanScript.SetState(human.human_state.brainwashing);               // 取得したhumanスクリプトの状態をbrainwashingに状態遷移
                }
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            count = cooltime + 10;
        }
    }
}
