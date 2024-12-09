using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToShowUI : MonoBehaviour
{
    // 表示するUIオブジェクト
    public GameObject uiPanel;

    void Start()
    {
        // シーン内で特定のUIオブジェクトを検索して設定
        if (uiPanel == null)
        {
            uiPanel = GameObject.Find("ui");
            Debug.Log("UIPanel が見つかりました。");
            uiPanel.GetComponent<CanvasGroup>().alpha = 1;
        }

        if (uiPanel == null)
        {
            Debug.LogError("UIPanel が見つかりません。スクリプトで自動設定するか、Inspector で設定してください。");
        }

        // シーン開始時にUIを非表示にする
        //if (uiPanel != null)
        //{
        //    uiPanel.SetActive(false);
        //}
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform && uiPanel != null)
                {
                    uiPanel.SetActive(!uiPanel.activeSelf);
                    //targetObject.GetComponent;

                }
            }
        }
    }
}
