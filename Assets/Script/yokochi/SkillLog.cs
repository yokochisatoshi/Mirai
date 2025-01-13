using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillLog : MonoBehaviour
{
    SkillLogManager.SkillType skillType = SkillLogManager.SkillType.NoData;
    SkillLogManager.StoreName storeName = SkillLogManager.StoreName.NoData;

    // 自身の画像
    [SerializeField] Image myImage;

    // 子オブジェクト(名前)の画像
    [SerializeField] Image nameImage;

    public int alievTime = 0;   // 出現してからのカウント
    public bool Select = false;

    // テクスチャ
    [SerializeField] Sprite Special1;
    [SerializeField] Sprite Special2;
    [SerializeField] Sprite Special3;
    [SerializeField] Sprite Special4;
    [SerializeField] Sprite Special5;

    [SerializeField] Sprite rivalSpecial1;
    [SerializeField] Sprite rivalSpecial2;

    [SerializeField] Sprite Hitsumabushi;
    [SerializeField] Sprite Kishimen;
    [SerializeField] Sprite Misokatsu;
    [SerializeField] Sprite TaiwanRamen;
    [SerializeField] Sprite Tebasaki;
    [SerializeField] Sprite Uirou;
    [SerializeField] Sprite rival;
    [SerializeField] Sprite Increase;

    // Start is called before the first frame update
    void Start()
    {
        myImage = this.gameObject.GetComponent<Image>();    // 変更する自身image取得
        nameImage = this.gameObject.transform.GetChild(0).GetComponent<Image>();    // 変更する子image取得
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        alievTime++;
    }

    // スキルログの内容セット関数
    public void SetSkillLogDate(SkillLogManager.StoreName _storeName, SkillLogManager.SkillType _skillType)
    {
        // データセット
        storeName = _storeName;
        skillType = _skillType;

        // 画像セット
        switch (storeName)
        {
            case SkillLogManager.StoreName.Hitumabushi:
                nameImage.sprite = Hitsumabushi;
                break;
            case SkillLogManager.StoreName.kisimen:
                nameImage.sprite = Kishimen;
                break;
            case SkillLogManager.StoreName.misokatu:
                nameImage.sprite = Misokatsu;
                break;
           case SkillLogManager.StoreName.TaiwanRamen:
                nameImage.sprite = TaiwanRamen;
                break;
            case SkillLogManager.StoreName.Tebasaki:
                nameImage.sprite = Tebasaki;
                break;
            case SkillLogManager.StoreName.uirou:
                nameImage.sprite = Uirou;
                break;
            case SkillLogManager.StoreName.rival1:
                nameImage.sprite = rival;
                break;
            case SkillLogManager.StoreName.rival2:
                nameImage.sprite = rival;
                break;
            case SkillLogManager.StoreName.NoData:

                break;
        }

        switch (skillType)
        {
            case SkillLogManager.SkillType.Special1:
                myImage.sprite = Special1;
                break;
            case SkillLogManager.SkillType.Special2:
                myImage.sprite = Special2;
                break;
            case SkillLogManager.SkillType.Special3:
                myImage.sprite = Special3;
                break;
            case SkillLogManager.SkillType.Special4:
                myImage.sprite = Special4;
                break;
            case SkillLogManager.SkillType.Special5:
                myImage.sprite = Special5;
                break;
            case SkillLogManager.SkillType.rivalSpecial1:
                myImage.sprite = rivalSpecial1;
                break;
            case SkillLogManager.SkillType.rivalSpecial2:
                myImage.sprite = rivalSpecial2;
                break;
            case SkillLogManager.SkillType.Increase:
                myImage.sprite = Increase;
                break;
            case SkillLogManager.SkillType.NoData:

                break;
        }
    }

}
