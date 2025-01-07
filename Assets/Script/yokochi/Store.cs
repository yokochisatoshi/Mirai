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
        SpeedUpSkill,
        addMoney
    }

    public GameObject SkillColli;            // 範囲型洗脳スキルの当たり判定用オブジェ
    public int cooltimeCount = 0;            // クールタイムのカウンタ
    public int cooltime = 100;               // 必殺技のクールタイム
    public int speedUpSkillTime = 100;       // スピードダウンの効果時間
    public int SmallBrainwashingSkillTime = 100;       // スピードダウンの効果時間
    public int skillTimeCount = 0;           // クールタイムのカウンタ
    public StorState state = StorState.nomal;
    public int addMoneyVal = 500;            // スキルで増やすお金

    PlayerData PLDataSc;

    // Start is called before the first frame update
    void Start()
    {
        PLDataSc = GameObject.Find("ManageData").GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void FixedUpdate()
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
                if(skillTimeCount > SmallBrainwashingSkillTime)
                {
                    SkillColli.SetActive(false);
                    skillTimeCount = 0;
                    state = StorState.nomal;
                }
                break;
            case StorState.SpeedUpSkill:
                SpeedUpSkill();
                state = StorState.nomal;
                break;
            case StorState.addMoney:
                PLDataSc.AddMoney(addMoneyVal);
                state = StorState.nomal;
                break;
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

    void SpeedUpSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // 存在するHumanタグを持っているオブジェクトを配列に格納
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjectsの要素分ループ
            humanScript = humanObjects[i].GetComponent<human>();              // humanスクリプト取得
            humanScript.speedUp = true;
        }

        skillTimeCount++;
        if (skillTimeCount > speedUpSkillTime)
        {
            if (humanScript != null) humanScript.speedUp = false;
            skillTimeCount = 0;
            state = StorState.nomal;
        }
    }

    public void UseSkill()
    {
        if (cooltimeCount >= cooltime)
        { // cooltime分時間が経ったら
            cooltimeCount = 0;
            int num = Random.Range(0, 100);
            if (num >= 0 && num < 25)
            {
                state = StorState.BrainwashingSkill;
            }
            else if (num >= 20 && num < 50)
            {
                state = StorState.SmallBrainwashingSkill;
                SkillColli.SetActive(true);
            }
            else if (num >= 50 && num < 80)
            {
                state = StorState.SpeedUpSkill;
            }
            else if (num >= 80 && num < 100)
            {
                state = StorState.addMoney;
            }
        }
        else
        {
            Debug.Log("まだコスト溜まってないが？");
        }
    }
}
