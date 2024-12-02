using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleIncrease : MonoBehaviour
{
    private bool isScaled = false;      // スケール拡大しているか
    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f);    // 拡大倍率
    private Vector3 originalScale;      // 元のサイズを保存

    // Start is called before the first frame update
    void Start()
    {
        // 初期サイズを保存
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) // 0: 左クリック
        //{
        //    // マウスの位置からRayを飛ばす
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    // Rayが当たったオブジェクトを判定
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // このスクリプトがアタッチされているオブジェクトをクリックした場合
        //        if (hit.transform == transform)
        //        {
        Debug.Log("Scale");
        // サイズを切り替える
        if (!isScaled)
        {
            Debug.Log("fadsfasdfa");
            StartCoroutine(SmoothScale(originalScale + scaleIncrease));
        }

        isScaled = !isScaled; // 状態を切り替える
        //        }
        //    }
        //}
    }
    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0)) // 0: 左クリック
    //    {
    //        // マウスの位置からRayを飛ばす
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        // Rayが当たったオブジェクトを判定
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            // このスクリプトがアタッチされているオブジェクトをクリックした場合
    //            if (hit.transform == transform)
    //            {
    //                // サイズを切り替える
    //                if (!isScaled)
    //                {
    //                    Debug.Log("fadsfasdfa");
    //                    StartCoroutine(SmoothScale(originalScale + scaleIncrease));
    //                }

    //                isScaled = !isScaled; // 状態を切り替える
    //            }
    //        }
    //    }
    //}

    IEnumerator SmoothScale(Vector3 targetScale)
    {
        float duration = 1.0f;      // 拡大にかける時間
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }
}

//public class ScaleIncrease : MonoBehaviour
//{
//    private bool isScaled = false;      // スケール拡大しているか
//    public Vector3 scaleIncrease = new Vector3(1.0f, 1.0f, 1.0f);    // 拡大倍率
//    private Vector3 originalScale;      // 元のサイズを保存

//    // Start is called before the first frame update
//    void Start()
//    {
//        // 初期サイズを保存
//        originalScale = transform.localScale;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0)) // 0: 左クリック
//        {
//            // マウスの位置からRayを飛ばす
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//            RaycastHit hit;

//            // Rayが当たったオブジェクトを判定
//            if (Physics.Raycast(ray, out hit))
//            {
//                // このスクリプトがアタッチされているオブジェクトをクリックした場合
//                if (hit.transform == transform)
//                {
//                    // サイズを切り替える
//                    if (!isScaled)
//                    {
//                        StartCoroutine(SmoothScale(originalScale + scaleIncrease));
//                    }

//                    isScaled = !isScaled; // 状態を切り替える
//                }
//            }
//        }
//    }

//    IEnumerator SmoothScale(Vector3 targetScale)
//    {
//        float duration = 1.0f;      // 拡大にかける時間
//        Vector3 startScale = transform.localScale;
//        float elapsedTime = 0f;

//        while (elapsedTime < duration)
//        {
//            transform.localScale = Vector3.Lerp(startScale, targetScale, elapsedTime / duration);
//            elapsedTime += Time.deltaTime;
//            yield return null;
//        }

//        transform.localScale = targetScale;
//    }
//}
