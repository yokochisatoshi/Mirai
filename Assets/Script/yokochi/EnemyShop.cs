using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        count++;
        if (count > cooltime)
        //if (Input.GetKey(KeyCode.Space))
        { // cooltime分時間が経ったら
            count = 0;

            int number = Random.Range(1, 100);  // ランダム判定用
            if (number >= 70)
            { // 70%で人間洗脳
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
            else if (number < 70 && number >= 85)
            { // 15%で人の足を遅く

            }
            else if (number < 85 && number >= 100)
            { // 15%でスコアの加算率低下

            }
        }
    }
}
