using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActions : MonoBehaviour
{
    public Button investButton;  // 増資ボタン
    public Button specialButton; // 必殺技ボタン
    public GameObject targetObject; // アクション対象のオブジェクト
    private bool isScaled = false;      // スケール拡大しているか
    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f);    // 拡大倍率
    private Vector3 originalScale;      // 元のサイズを保存

    //public GameObject originalObject;  // オリジナルのオブジェクト
    //private GameObject cloneObject;    // クローンオブジェクト

    void Start()
    {
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

        // 初期サイズを targetObject から取得
        originalScale = transform.localScale;

        //// オリジナルのオブジェクトをクローン
        //cloneObject = Instantiate(originalObject, transform.position, transform.rotation);
    }

    // 増資ボタンがクリックされたときの処理
    void HandleInvestButton()
    {
        // クローンオブジェクトのスケールを変更
        //if (cloneObject != null)
        //{
        //Debug.Log("拡大");
        //Vector3 targetScale = cloneObject.transform.localScale + scaleIncrease;
        //StartCoroutine(SmoothScale(cloneObject, targetScale));
        //}

        //// サイズを切り替える
        //if (!isScaled)
        //{
        Debug.Log("拡大");
        StartCoroutine(SmoothScale(originalScale + scaleIncrease));
        //}

        isScaled = !isScaled; // 状態を切り替える
    }

    // 必殺技ボタンがクリックされたときの処理
    void HandleSpecialButton()
    {
        // 必殺技のアクションをここに記述
        Debug.Log("必殺技発動！");
        // 必要に応じて特殊なアクションを追加
    }

    IEnumerator SmoothScale(Vector3 targetScale)
    {
        float duration = 0.5f; // 拡大にかける時間
        Vector3 startScale = targetObject.transform.localScale;
        float elapsedTime = 0f;

        // 徐々にスケールを変更
        while (elapsedTime < duration)
        {
            targetObject.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime; // 時間を加算
            yield return null; // 次のフレームまで待機
        }

        Debug.Log((targetScale));

        // 最後に確実にターゲットスケールに設定
        targetObject.transform.localScale = targetScale;
    }

    IEnumerator SmoothScale(GameObject target, Vector3 targetScale)
    {
        float duration = 0.5f;
        Vector3 startScale = target.transform.localScale;
        float elapsedTime = 0f;

        // 徐々にスケールを変更
        while (elapsedTime < duration)
        {
            target.transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 最後に確実にターゲットスケールに設定
        target.transform.localScale = targetScale;
    }
}
