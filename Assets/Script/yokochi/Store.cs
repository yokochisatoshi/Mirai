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
        addMoney,
        EnemySkillDownTimeSkill,
    }

    public GameObject SkillColli;            // �͈͌^���]�X�L���̓����蔻��p�I�u�W�F
    public int cooltimeCount = 0;            // �N�[���^�C���̃J�E���^
    public int cooltime = 100;               // �K�E�Z�̃N�[���^�C��
    public int speedUpSkillTime = 100;       // �X�s�[�h�_�E���̌��ʎ���
    public int SmallBrainwashingSkillTime = 100;       // �X�s�[�h�_�E���̌��ʎ���
    public int skillTimeCount = 0;           // �N�[���^�C���̃J�E���^
    public StorState state = StorState.nomal;
    int addMoneyVal = 3000;            // �X�L���ő��₷����
    public int EneTimeDownVal = 100;

    PlayerData PLDataSc;

    SkillLogManager SkillLogSc;
    SkillLogManager.StoreName storeName;

    // ��Y�ǉ�
    private EffectManager SpecialEffectManager;        // �Ŕ������̃G�t�F�N�g

    // Start is called before the first frame update
    void Start()
    {
        PLDataSc = GameObject.Find("ManageData").GetComponent<PlayerData>();
        SkillLogSc = GameObject.Find("ManageSkillLog").GetComponent<SkillLogManager>();

        // ��Y�ǉ�
        SpecialEffectManager = FindObjectOfType<EffectManager>();

        // �ʓ|�������̂ł����ŃX�L�����O�̂Ȃ܂��Z�b�g
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

                // ��Y�ǉ�
                GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(transform.position);

                break;
            case StorState.SmallBrainwashingSkill:
                skillTimeCount++;
                if(skillTimeCount > SmallBrainwashingSkillTime)
                {
                    SkillColli.SetActive(false);
                    skillTimeCount = 0;
                    state = StorState.nomal;

                    // ��Y�ǉ�
                    Effect = SpecialEffectManager.SpawnSpecialEffect(transform.position);
                }

                break;
            case StorState.SpeedUpSkill:
                SpeedUpSkill();
                state = StorState.nomal;

                // ��Y�ǉ�
                Effect = SpecialEffectManager.SpawnSpecialEffect(transform.position);

                break;
            case StorState.addMoney:
                PLDataSc.AddMoney(addMoneyVal);
                state = StorState.nomal;

                // ��Y�ǉ�
                Effect = SpecialEffectManager.SpawnSpecialEffect(transform.position);

                break;
            case StorState.EnemySkillDownTimeSkill:
                EnemySkillDownTimeSkill();
                state = StorState.nomal;

                // ��Y�ǉ�
                Effect = SpecialEffectManager.SpawnSpecialEffect(transform.position);

                break;
        }

    }

    public food_type GetFoodType()
    {
        return food;
    }

    void BrainwashingSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            human humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
            if (humanScript.GetState() == (int)human.human_state.normal)
            { // �擾����humanScript�̏�Ԃ�normal�Ȃ�
                humanScript.SetFavoriteFood(food);
                humanScript.SetTargetAllyStore(this.gameObject);                   // �擾����human�X�N���v�g�̌����������̓X�����̃I�u�W�F�N�g�ɂ���
                humanScript.SetState(human.human_state.allyBrainwashing);          // �擾����human�X�N���v�g�̏�Ԃ�allyBrainwashing�ɏ�ԑJ��
            }
        }

        state = StorState.nomal;
    }

    void SpeedUpSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        human humanScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
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
        { // cooltime�����Ԃ��o������
            cooltimeCount = 0;
            int num = Random.Range(0, 100);
            if (num >= 0 && num < 20)
            {
                state = StorState.BrainwashingSkill;
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special1);
            }
            else if (num >= 20 && num < 40)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special4);
                state = StorState.SmallBrainwashingSkill;
                SkillColli.SetActive(true);
            }
            else if (num >= 40 && num < 60)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special3);
                state = StorState.SpeedUpSkill;
            }
            else if (num >= 60 && num < 80)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special5);
                state = StorState.addMoney;
            }
            else if (num >= 80 && num < 100)
            {
                SkillLogSc.CreateSkillLog(storeName, SkillLogManager.SkillType.Special2);
                state = StorState.EnemySkillDownTimeSkill;
            }
            SoundManager.Instance.PlaySound("Special");     // ��Y�@�T�E���h�ǉ�����
        }
        else
        {
            Debug.Log("�܂��R�X�g���܂��ĂȂ����H");
        }
    }

    void EnemySkillDownTimeSkill()
    {
        GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("EnemyStore");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
        EnemyShop EnemyScript = null;
        for (int i = 0; i < humanObjects.Length; i++)
        { // humanObjects�̗v�f�����[�v
            EnemyScript = humanObjects[i].GetComponent<EnemyShop>();              // human�X�N���v�g�擾
            EnemyScript.cooltimeCount -= EneTimeDownVal;

            if(EnemyScript.cooltimeCount < 0)
            {
                EnemyScript.cooltimeCount = 0;
            }
        }
    }
}
