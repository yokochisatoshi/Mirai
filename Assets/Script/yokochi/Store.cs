using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public enum food_type
    {
        Misokatu,
        Uirou,
        Hitsumabushi,
        Tebasaki,
        TaiwanRamen,
        Kishimen,
    }

    public food_type food;

    public enum StorState
    {
        nomal,
        BrainwashingSkill,
        SmallBrainwashingSkill,
        cancellationSkill,
        addMoney,
        EnemySkillDownTimeSkill,
    }

    public GameObject SkillColli;            // 範囲型洗脳スキルの当たり判定用オブジェ
    public int cooltimeCount = 0;            // クールタイムのカウンタ
    public int cooltime = 100;               // 必殺技のクールタイム
    public int SmallBrainwashingSkillTime = 100;       // 効果時間
    public int skillTimeCount = 0;           // クールタイムのカウンタ
    public StorState state = StorState.nomal;
    int addMoneyVal = 3000;            // スキルで増やすお金
    public int EneTimeDownVal = 100;

    PlayerData PLDataSc;

    bool cancellationFlag = false;
    public float cancellationPer = 50;
    public float brainwashingPer = 20;
    public float smallBrainwashingPer = 30;
    public float addMoneyPer = 30;



    SkillLogManager SkillLogSc;
    SkillLogManager.StoreName storeName;

    // Start is called before the first frame update
    void Start()
    {
        PLDataSc = GameObject.Find("ManageData").GetComponent<PlayerData>();
        SkillLogSc = GameObject.Find("ManageSkillLog").GetComponent<SkillLogManager>();

        // 面倒くさいのでここでスキルログのなまえセット
        switch (food)
        {
            case food_type.Misokatu:
                storeName = SkillLogManager.StoreName.misokatu;
                break;
            case food_type.Uirou:
                storeName = SkillLogManager.StoreName.uirou;
                break;
            case food_type.Hitsumabushi:
                storeName = SkillLogManager.StoreName.Hitumabushi;
                break;
            case food_type.Tebasaki:
                storeName = SkillLogManager.StoreName.Tebasaki;
                break;
            case food_type.TaiwanRamen:
                storeName = SkillLogManager.StoreName.TaiwanRamen;
                break;
            case food_type.Kishimen:
                storeName = SkillLogManager.StoreName.kisimen;
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerData.Instance.bGameStart)
        {


            switch (state)
            {
                case StorState.nomal:
                    cooltimeCount++;
                    if (cooltimeCount >= cooltime)
                    {
                        cooltimeCount = cooltime;
                    }

                    break;
                case StorState.BrainwashingSkill:
                    BrainwashingSkill();
                    state = StorState.nomal;

                    break;
                case StorState.SmallBrainwashingSkill:
                    skillTimeCount++;
                    if (skillTimeCount > SmallBrainwashingSkillTime)
                    {
                        SkillColli.SetActive(false);
                        skillTimeCount = 0;
                        state = StorState.nomal;
                    }

                    break;
                case StorState.cancellationSkill:
                    CancellationSkill();
                    state = StorState.nomal;
                    break;
                case StorState.addMoney:
                    PLDataSc.AddMoney(addMoneyVal);
                    state = StorState.nomal;
                    break;
                case StorState.EnemySkillDownTimeSkill:
                    EnemySkillDownTimeSkill();
                    state = StorState.nomal;

                    break;
            }
        }
    }

    public food_type GetFoodType()
    {
        return food;
    }

    void BrainwashingSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // 存在するHumanタグを持っているオブジェクトを配列に格納
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjectsの要素分ループ
            human humanScript = humanObjects[i].GetComponent<human>();              // humanスクリプト取得
            if (humanScript.GetState() == (int)human.human_state.normal)
            { // 取得したhumanScriptの状態がnormalなら
                humanScript.SetFavoriteFood(food);
                humanScript.SetTargetAllyStore(this.gameObject);                   // 取得したhumanスクリプトの向かう味方の店をこのオブジェクトにする
                humanScript.SetState(human.human_state.allyBrainwashing);          // 取得したhumanスクリプトの状態をallyBrainwashingに状態遷移
            }
        }

        state = StorState.nomal;
    }

    void CancellationSkill()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("EnemyStore");
        EnemyShop enemyScript = null;
        for (int i = 0; i < enemyObjects.Length; i++)
        { // humanObjectsの要素分ループ
            enemyScript = enemyObjects[i].GetComponent<EnemyShop>();              // humanスクリプト取得
            enemyScript.Cancellation();
        }
        state = StorState.nomal;
    }

    public void UseSkill()
    {
        if (cooltimeCount >= cooltime)
        { // cooltime分時間が経ったら
            cooltimeCount = 0;
            int num = Random.Range(0, 100);

            // スピード解除フラグ
            float Per;
            float cancellation;
            GameObject[] EnemyObjects = GameObject.FindGameObjectsWithTag("EnemyStore");     // 存在するenemysoreタグを持っているオブジェクトを配列に格納
            for (int i = 0; i < EnemyObjects.Length; i++)
            { // humanObjectsの要素分ループ
                EnemyShop EnemyScript = EnemyObjects[i].GetComponent<EnemyShop>();              // スクリプト取得
                if (EnemyScript.state == EnemyShop.EnemyStorState.speedUpSkill || EnemyScript.state == EnemyShop.EnemyStorState.SpeedDownSkill)
                {
                    cancellationFlag = true;                
                }
            }
            if (cancellationFlag == true)
            {
                cancellation = cancellationPer;
                Per = 100 - cancellation;
            }
            else
            {
                Per = 100;
                cancellation = 0;
            }
            cancellationFlag = false;

            if (num >= 0 && num < cancellation)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special3);
                state = StorState.cancellationSkill;
            }
            else if (num >= cancellation && num < cancellation + (Per * (smallBrainwashingPer / 10)))
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special4);
                state = StorState.SmallBrainwashingSkill;
                SkillColli.SetActive(true);
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 10)) && num < cancellation + (Per * (smallBrainwashingPer / 10)) + (Per * (brainwashingPer / 10)))
            {
                state = StorState.BrainwashingSkill;
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special1);
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 10)) + (Per * (brainwashingPer / 10)) && num < cancellation + (Per * (smallBrainwashingPer / 10)) + (Per * (brainwashingPer / 10)) + (Per * (addMoneyPer / 10)))
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special5);
                state = StorState.addMoney;
            }
            else if (num >= cancellation + (Per * (smallBrainwashingPer / 10)) + (Per * (brainwashingPer / 10)) + (Per * (addMoneyPer / 10)) && num < 100)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special2);
                state = StorState.EnemySkillDownTimeSkill;
            }
            
        }
        else
        {
            Debug.Log("まだコスト溜まってないが？");
        }
    }

    void EnemySkillDownTimeSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("EnemyStore");     // 存在するHumanタグを持っているオブジェクトを配列に格納
        EnemyShop EnemyScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjectsの要素分ループ
            EnemyScript = humanObjects[i].GetComponent<EnemyShop>();              // humanスクリプト取得
            EnemyScript.cooltimeCount -= EneTimeDownVal;

            if (EnemyScript.cooltimeCount < 0)
            {
                EnemyScript.cooltimeCount = 0;
            }
        }
    }
}