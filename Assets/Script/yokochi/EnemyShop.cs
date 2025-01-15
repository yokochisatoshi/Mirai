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
        SpeedDownSkill,
        subtractMoney,
        speedUpSkill,
    }

    public int cooltime = 100;      // 必殺技のクールタイム
    public int cooltimeCount = 0;   // クールタイムのカウンタ

    public int speedDownSkillTime = 100;      // スピードダウンの効果時間
    public int skillTimeCount = 0;           // クールタイムのカウンタ
    public int speedUpSkillTime = 100;      // スピードアップの効果時間
    public int skillTimeCount1 = 0;           // クールタイムのカウンタ
    public EnemyStorState state = EnemyStorState.nomal;

    SkillLogManager SkillLogSc;

    GameObject ManageData;
    PlayerData script;
    int money = 300;

    // 川添追加
    private EffectManager RivalSpecialEffectManager;        // 必殺技時のエフェクト

    // Start is called before the first frame update
    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

        SkillLogSc = GameObject.Find("ManageSkillLog").GetComponent<SkillLogManager>();

        // 川添追加
        RivalSpecialEffectManager = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart)
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
                        if (num >= 0 && num < 50)
                        {
                            state = EnemyStorState.BrainwashingSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial1);
                        }
                        else if (num >= 50 && num < 70)
                        {
                            state = EnemyStorState.SpeedDownSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.rival1, SkillLogManager.SkillType.rivalSpecial2);
                        }
                        else if (num >= 70 && num < 70)
                        {
                            state = EnemyStorState.subtractMoney;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.NoData, SkillLogManager.SkillType.Special1);
                        }
                        else if (num >= 70 && num < 100)
                        {
                            state = EnemyStorState.speedUpSkill;
                            SkillLogSc.CreateSkillLog(SkillLogManager.StoreName.NoData, SkillLogManager.SkillType.Special1);
                        }
                    }
                    break;
                case EnemyStorState.SpeedDownSkill:
                    SpeedDownSkill();
                    break;
                case EnemyStorState.BrainwashingSkill:
                    BrainwashingSkill();
                    break;
                case EnemyStorState.subtractMoney:
                    script.SubtractMoney(money);
                    // 川添追加
                    GameObject effect = RivalSpecialEffectManager.SpawnRivalSpecialEffect(
                                    new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
                    state = EnemyStorState.nomal;
                    break;
                case EnemyStorState.speedUpSkill:
                    SpeedUpSkill();
                    break;
                    
            }
        }
    }


    void BrainwashingSkill()
    {
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

        // 川添追加
        GameObject effect = RivalSpecialEffectManager.SpawnRivalSpecialEffect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
    }

    void SpeedDownSkill()
    {
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

            // 川添追加
            GameObject effect = RivalSpecialEffectManager.SpawnRivalSpecialEffect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        }

    }

    void SpeedUpSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // 存在するHumanタグを持っているオブジェクトを配列に格納
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjectsの要素分ループ
            humanScript = humanObjects[i].GetComponent<human>();              // humanスクリプト取得
            humanScript.speedUpDe = true;
        }

        skillTimeCount1++;
        if (skillTimeCount1 > speedUpSkillTime)
        {
            if (humanScript != null) humanScript.speedUpDe = false;
            skillTimeCount1 = 0;
            state = EnemyStorState.nomal;

            // 川添追加
            GameObject effect = RivalSpecialEffectManager.SpawnRivalSpecialEffect(
                        new Vector3(transform.position.x, transform.position.y - 2.0f, transform.position.z));
        }
    }
}
