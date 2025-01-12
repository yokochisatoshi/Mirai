using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows;        川添いじった

public class EnemyShop : MonoBehaviour
{
    public enum EnemyStorState
    {
        nomal,
        BrainwashingSkill,
        SpeedDownSkill
    }

    public int cooltime = 100;      // 必殺技のクールタイム
    public int cooltimeCount = 0;   // クールタイムのカウンタ

    public int speedDownSkillTime = 100;      // スピードダウンの効果時間
    public int skillTimeCount = 0;           // クールタイムのカウンタ
    public EnemyStorState state = EnemyStorState.nomal;

    // 川添追加
    bool RivalSpecial2 = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // 川添いじった　スペースキーを押したらcountをcooltime以上にする

        if (cooltimeCount > cooltime)
        { // cooltime分時間が経ったら
            //BrainwashingSkill();
            
            // SpeedDownSkill();
        }

        switch (state)
        {
            case EnemyStorState.nomal:
                cooltimeCount++;
                if (cooltimeCount > cooltime)
                { // cooltime分時間が経ったら
                    cooltimeCount = 0;
                    int num = Random.Range(0, 100);
                    if(num >= 0 && num < 50)
                    {
                        state = EnemyStorState.BrainwashingSkill;
                    }
                    else if (num >= 50 && num <100)
                    {
                        state = EnemyStorState.SpeedDownSkill;
                    }
                }
                break;
            case EnemyStorState.SpeedDownSkill:
                SpeedDownSkill();
                break;
            case EnemyStorState.BrainwashingSkill:
                BrainwashingSkill();
                break;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //cooltimeCount = cooltime + 10;
        }
    }

    void BrainwashingSkill()
    {
        SoundManager.Instance.PlaySound("RivalSpecial");     // 川添　サウンド追加した

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

        state = EnemyStorState.nomal;
        
    }

    void SpeedDownSkill()
    {
        if (!RivalSpecial2)
        { 
            SoundManager.Instance.PlaySound("RivalSpecial");     // 川添　サウンド追加した
            RivalSpecial2 = true;
        }

        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // 存在するHumanタグを持っているオブジェクトを配列に格納
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjectsの要素分ループ
            humanScript = humanObjects[i].GetComponent<human>();              // humanスクリプト取得
            humanScript.speedDown = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedDownSkillTime)
        {
            if(humanScript != null) humanScript.speedDown = false;
            skillTimeCount = 0;
            state = EnemyStorState.nomal;
            RivalSpecial2 = false;          // 川添追加
        }
       
    }
}
