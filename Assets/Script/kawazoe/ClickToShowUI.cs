using UnityEngine;

public class ClickToShowUI : MonoBehaviour
{
    // 表示するUIオブジェクト
    public GameObject uiPanel;

    private GameObject ManageData;
    public BuilldingData builldingData;

    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        builldingData = ManageData.GetComponent<BuilldingData>();

        // シーン内で特定のUIオブジェクトを検索して設定
        if (uiPanel == null)
        {
            GameObject gameObject1 = GameObject.Find("UiToShopCanvas");
            uiPanel = gameObject1;
            Debug.Log("UIPanel が見つかりました。");
        }

        if (uiPanel == null)
        {
            Debug.LogError("UIPanel が見つかりません。スクリプトで自動設定するか、Inspector で設定してください。");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.Log("クリックは受け付けています！");

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    builldingData.selectedModel = hit.transform.gameObject;
                    uiPanel.GetComponent<CanvasGroup>().alpha = 1.0f; // UIを表示する
                    Debug.Log("モデルに当たっています！");
                }
            }
        }

        if (builldingData.selectedModel == null || Input.GetMouseButtonDown(1))
        {
            uiPanel.GetComponent<CanvasGroup>().alpha = 0f;
            builldingData.selectedModel = null;
            //Debug.Log("alhpa値を変更しました！");
        }
    }
}

