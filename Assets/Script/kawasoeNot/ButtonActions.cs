using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public Button investButton;  // 増資ボタン
    public Button specialButton; // 必殺技ボタン

    private GameObject ManageData;
    private BuilldingData builldingData;

    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        builldingData = ManageData.GetComponent<BuilldingData>();

        // ボタンにクリックイベントを設定
        if (investButton != null)
        {
            investButton.onClick.AddListener(HandleInvestButton);
        }
        else
        {
            Debug.LogError("investButton が設定されていません。");
        }

        if (specialButton != null)
        {
            specialButton.onClick.AddListener(HandleSpecialButton);
        }
        else
        {
            Debug.LogError("specialButton が設定されていません。");
        }

    }

    // 増資ボタンがクリックされたときの処理
    void HandleInvestButton()
    {
        if (builldingData.selectedModel != null)
        {
            builldingData.IsScale = true;
        }
    }

    // 必殺技ボタンがクリックされたときの処理
    void HandleSpecialButton()
    {
        // 必殺技のアクションをここに記述
        Debug.Log("必殺技発動！");
        // 必要に応じて特殊なアクションを追加
    }

}
