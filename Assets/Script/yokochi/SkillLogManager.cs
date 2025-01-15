using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillLogManager : MonoBehaviour
{
    public enum StoreName
    {
        misokatu,
        uirou,
        kisimen,
        Hitumabushi,
        TaiwanRamen,
        Tebasaki,
        rival1,
        rival2,
        NoData
    }

    public enum SkillType
    {
        Special1,
        Special2,
        Special3,
        Special4,
        Special5,
        rivalSpecial1,
        rivalSpecial2,
        rivalSpecial3,
        rivalSpecial4,
        Increase,
        NoData
    }

    public Object SkillLogObj;
    Vector3 position;
    public GameObject SkillLogParent;
    List<GameObject> SkillLogs = new List<GameObject>();
    public int destroyCount = 10;

    RectTransform size;

    public float slideSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        size = this.gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            CreateSkillLog(StoreName.kisimen, SkillType.Special3);
        }

        for (int i = 0; i < SkillLogs.Count; i++)
        {
            SkillLog skillLogCs = SkillLogs[i].GetComponent<SkillLog>();    // スクリプト取得

            // ヒエラルキー変更用(かなり強引)
            skillLogCs.Select = false;
            SkillLogs[i].transform.SetSiblingIndex(i);

            // 移動処理 面倒くさい
            Vector3 pos = SkillLogs[i].transform.position;
            
            if (0 > slideSpeed)
            {
                if (pos.x < transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // 横移動
                    pos.x -= slideSpeed;
                }
                if (pos.x >= transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // 縦移動
                    pos.x = transform.position.x + size.sizeDelta.x / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2;
                    if (pos.y < transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    { // 横移動
                        pos.y += Mathf.Abs(slideSpeed);
                    }
                    if (pos.y >= transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    {
                        pos.y = transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count);
                    }
                }
            }
            else
            {
                if (pos.x > transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // 横移動
                    pos.x -= slideSpeed;
                }
                if (pos.x <= transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2)
                { // 縦移動
                    pos.x = transform.position.x - size.sizeDelta.x / 2 + SkillLogs[i].GetComponent<RectTransform>().sizeDelta.x * SkillLogParent.GetComponent<RectTransform>().localScale.x / 2;
                    if (pos.y < transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    { // 横移動
                        pos.y += Mathf.Abs(slideSpeed);
                    }
                    if (pos.y >= transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count))
                    {
                        pos.y = transform.position.y + size.sizeDelta.y / 2 - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y / 2 - i * ((size.sizeDelta.y - SkillLogs[i].GetComponent<RectTransform>().sizeDelta.y * SkillLogParent.GetComponent<RectTransform>().localScale.y) / SkillLogs.Count);
                    }
                }
            }

            SkillLogs[i].transform.position = pos;

            // 削除処理
            if (skillLogCs.alievTime > destroyCount)
            {
                Destroy(SkillLogs[i]);  // ログ削除
                SkillLogs.RemoveAt(i);  // リスト要素削除
            }
        }

        //RaycastAllの引数（PointerEventData）作成
        PointerEventData pointData = new PointerEventData(EventSystem.current);

        //RaycastAllの結果格納用List
        List<RaycastResult> RayResult = new List<RaycastResult>();

        //PointerEventDataにマウスの位置をセット
        pointData.position = Input.mousePosition;
        //RayCast（スクリーン座標）
        EventSystem.current.RaycastAll(pointData, RayResult);

        foreach (RaycastResult result in RayResult)
        {
            if(result.gameObject.GetComponent<SkillLog>() != null)
            {
                result.gameObject.GetComponent<SkillLog>().Select = true;
            }
        }

        // ヒエラルキー更新
        for (int i = 0; i < SkillLogs.Count; i++)
        {
            SkillLog skillLogCs = SkillLogs[i].GetComponent<SkillLog>();    // スクリプト取得

            if (skillLogCs.Select == true)
            {
                SkillLogs[i].transform.SetAsLastSibling();
            }
        }

    }

    // スキルログ生成関数
    public void CreateSkillLog(StoreName storeName, SkillType skillType)
    {
        GameObject obj;

        // スキルログ作成
        obj = Instantiate(SkillLogObj, SkillLogParent.transform, false) as GameObject;

        // スキルログ管理リストに格納
        SkillLogs.Add(obj);

        // スキルログ情報セット
        obj.GetComponent<SkillLog>().SetSkillLogDate(storeName, skillType);
    }
}
