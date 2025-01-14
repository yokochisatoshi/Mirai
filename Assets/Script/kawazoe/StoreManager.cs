using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public Vector3 scaleIncrease; // 拡大サイズ

    public GameObject MisokatuModel;
    public GameObject UirouModel;
    public GameObject HitsumabushiModel;
    public GameObject TebasakiModel;
    public GameObject TaiwanRamenModel;
    public GameObject KishimenModel;

    public int MisokatsuLevel = 1;  // 現在のレベル
    public int UirouLevel = 1;  // 現在のレベル
    public int HitsumabushiLevel = 1;  // 現在のレベル
    public int TebasakiLevel = 1;  // 現在のレベル
    public int TaiwanRamenLevel = 1;  // 現在のレベル
    public int KishimenLevel = 1;  // 現在のレベル

    private int maxLevel = 3; // 最大レベル

    private EffectManager IncreaseOfCapitalEffectManager;        // 増資時のエフェクト
    private EffectManager SpecialEffectManager;                  // 必殺技時のエフェクト

    // 横地追加-----------------------------------------------------------------------
    public GameObject skillLogManager;
    SkillLogManager SkillLogCs;

    // Start is called before the first frame update
    void Start()
    {
        SkillLogCs = skillLogManager.GetComponent<SkillLogManager>();

        IncreaseOfCapitalEffectManager = FindObjectOfType<EffectManager>();
        SpecialEffectManager = FindObjectOfType<EffectManager>();
    }
    //-----------------------------------------------------------------------------------

    // 味噌カツ店増資
    public void OperateMisokatuScaleIncrease()
    {
        if (MisokatsuLevel < maxLevel)
        {
            MisokatsuLevel++;
            Debug.Log("Misokatuを増資します");

            Vector3 newScale = MisokatuModel.transform.localScale + scaleIncrease;
            MisokatuModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(MisokatuModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.misokatu, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // 味噌カツ店必殺技
    public void OperateMisokatuSpecial()
    {
        Debug.Log("Misokatuが必殺技を使います");
        MisokatuModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(MisokatuModel.transform.position);
    }

    // ういろう店増資
    public void OperateUirouScaleIncrease()
    {
        if (UirouLevel < maxLevel)
        {
            UirouLevel++;
            Debug.Log("Uirouを増資します");

            Vector3 newScale = UirouModel.transform.localScale + scaleIncrease;
            UirouModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(UirouModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.uirou, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // ういろう店必殺技
    public void OperateUirouSpecial()
    {
        Debug.Log("Uirouが必殺技を使います");
        UirouModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(UirouModel.transform.position);
    }

    // ひつまぶし店増資
    public void OperateHitsumabushiScaleIncrease()
    {
        if (HitsumabushiLevel < maxLevel)
        {
            HitsumabushiLevel++;
            Debug.Log("Hitsumabushiを増資します");

            Vector3 newScale = HitsumabushiModel.transform.localScale + scaleIncrease;
            HitsumabushiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(HitsumabushiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Hitumabushi, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // ひつまぶし店必殺技
    public void OperateHitshmabushiSpecial()
    {
        Debug.Log("Hitsumabushiが必殺技を使います");
        HitsumabushiModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(HitsumabushiModel.transform.position);
    }

    // 手羽先店増資
    public void OperateTebasakiScaleIncrease()
    {
        if (TebasakiLevel < maxLevel)
        {
            TebasakiLevel++;
            Debug.Log("TebasakiModelを増資します");

            Vector3 newScale = TebasakiModel.transform.localScale + scaleIncrease;
            TebasakiModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TebasakiModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.Tebasaki, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }
    // 手羽先店必殺技
    public void OperateTebasakiSpecial()
    {
        Debug.Log("TebasakiModelが必殺技を使います");
        TebasakiModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(TebasakiModel.transform.position);
    }

    // 台湾ラーメン店増資
    public void OperateTaiwanRamenScaleIncrease()
    {
        if (TaiwanRamenLevel < maxLevel)
        {
            TaiwanRamenLevel++;
            Debug.Log("TaiwanRamenを増資します");

            Vector3 newScale = TaiwanRamenModel.transform.localScale + scaleIncrease;
            TaiwanRamenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(TaiwanRamenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.TaiwanRamen, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // 台湾ラーメン店必殺技
    public void OperateTaiwanRamenSpecial()
    {
        Debug.Log("TaiwanRamenが必殺技を使います");
        TaiwanRamenModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(TaiwanRamenModel.transform.position);
    }

    // きしめん店増資
    public void OperateKishimenScaleIncrease()
    {
        if (KishimenLevel < maxLevel)
        {
            KishimenLevel++;
            Debug.Log("Kishimenを増資します");

            Vector3 newScale = KishimenModel.transform.localScale + scaleIncrease;
            KishimenModel.transform.localScale = newScale;

            SoundManager.Instance.PlaySound("Applause");
            SoundManager.Instance.PlaySound("IncreaseOfCapital");

            GameObject Effect = IncreaseOfCapitalEffectManager.SpawnIncreaseOfCapitalEffect(KishimenModel.transform.position);

            SkillLogCs.CreateSkillLog(SkillLogManager.StoreName.kisimen, SkillLogManager.SkillType.Increase);  // 増資ログ生成(横地追加)
        }
    }

    // きしめん店必殺技
    public void OperateKishimenSpecial()
    {
        Debug.Log("Kishimenが必殺技を使います");
        KishimenModel.GetComponent<Store>().UseSkill();

        SoundManager.Instance.PlaySound("Special");

        GameObject Effect = SpecialEffectManager.SpawnSpecialEffect(KishimenModel.transform.position);
    }
}
