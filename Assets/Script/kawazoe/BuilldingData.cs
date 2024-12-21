using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilldingData : MonoBehaviour
{
    public GameObject prefab; // 元となるPrefab
    public List<GameObject> BuilldingPrefabList = new List<GameObject>(); // 建物クローンを管理するリスト

    public Vector3 scaleIncrease = new Vector3(0.5f, 0.5f, 0.5f); // 拡大サイズ

    public GameObject selectedModel = null; // 現在選択中のモデル
    public bool IsScale = false;            // 増資可能か

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (selectedModel != null && IsScale)
        {
            Vector3 newScale = selectedModel.transform.localScale + scaleIncrease;
            selectedModel.transform.localScale = newScale;
            //SmoothScale(newScale);
            Debug.Log($"モデル {selectedModel.name} のスケールを変更しました: {newScale}");

            // 初期化
            selectedModel = null;
            IsScale = false;
        }

        // リストの状態をログで確認
        //LogPrefabList();
    }

    public void AddBuillding()
    {
        BuilldingPrefabList.Add(prefab);
    }

    public void LogPrefabList()
    {
        Debug.Log($"現在のPrefabリストの内容（{BuilldingPrefabList.Count} 件）：");
        for (int i = 0; i < BuilldingPrefabList.Count; i++)
        {
            Debug.Log($"リスト[{i}] = {BuilldingPrefabList[i].name}, Position: {BuilldingPrefabList[i].transform.position}");
        }
    }

    public bool Contains(GameObject obj)
    {
        return BuilldingPrefabList.Contains(obj);
    }

    // 拡大を徐々にしたかったが、関数が上手く機能しないのでとりあえず無し。↓

    //IEnumerator SmoothScale(Vector3 targetScale)
    //{
    //    float duration = 0.5f;      // 拡大にかける時間
    //    Vector3 startScale = selectedModel.transform.localScale;
    //    float elapsedTime = 0f;

    //    while (elapsedTime < duration)
    //    {
    //        selectedModel.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
    //        elapsedTime += Time.deltaTime;
    //        yield return null;
    //    }

    //    selectedModel.transform.localScale = targetScale;
    //}
}


