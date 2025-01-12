using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // 画像
    public RectTransform targetTransform;    // 拡大・移動する対象
    public Image targetImage;                // 画像切り替え対象
    public Sprite hoverSprite;               // ホバー時の画像
    public Sprite defaultSprite;             // デフォルト画像
    public float scaleFactor;                // 拡大率
    public Vector2 moveOffset;               // 移動量
    public GameObject ScaleIncreaseButton;   // 表示するボタン
    public GameObject SpecialButton;
    public float animationSpeed = 20f;       // アニメーション速度

    private Vector3 ImageOriginalScale;
    private Vector2 ImageOriginalPosition;

    // Level
    private RectTransform LevelUiRectTransform; // オブジェクトのRectTransform

    public RectTransform levelUI;            // レベルUIのRectTransform
    public float LevelUiScaleFactor; // ホバー時のスケール
    public Vector2 LevelUiMoveOffset; // ホバー時の位置オフセット

    private Vector3 LevelUiOriginalScale; // 初期スケール
    private Vector2 LevelUiOriginalPosition; // 初期位置

    // 横地追加
    public GameObject GugeUi;   // 必殺技ゲージ

    void Start()
    {
        // 初期値を記録
        ImageOriginalScale = targetTransform.localScale;
        ImageOriginalPosition = targetTransform.anchoredPosition;

        LevelUiOriginalScale = levelUI.localScale;
        LevelUiOriginalPosition = levelUI.localPosition;

        LevelUiRectTransform = levelUI;

        // 初期状態でボタンを非表示
        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(ImageOriginalScale * scaleFactor, ImageOriginalPosition + moveOffset, hoverSprite, true));
        StartCoroutine(LevelUiAnimateToState(LevelUiOriginalScale * LevelUiScaleFactor, LevelUiOriginalPosition + LevelUiMoveOffset));

        targetTransform.transform.SetAsLastSibling();

        ScaleIncreaseButton.SetActive(true);
        SpecialButton.SetActive(true);

        // 横地追加
        GugeUi.SetActive(false);    // 必殺技ゲージ消す
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(ImageOriginalScale, ImageOriginalPosition, defaultSprite, false));
        StartCoroutine(LevelUiAnimateToState(LevelUiOriginalScale, LevelUiOriginalPosition));

        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);

        // 横地追加
        GugeUi.SetActive(true);    // 必殺技ゲージ出す
    }

    private System.Collections.IEnumerator AnimateToState(Vector3 targetScale, Vector2 targetPosition, Sprite targetSprite, bool showButtons)
    {
        // スムーズに拡大・移動
        while (Vector3.Distance(targetTransform.localScale, targetScale) > 0.01f ||
               Vector2.Distance(targetTransform.anchoredPosition, targetPosition) > 0.01f)
        {
            targetTransform.localScale = Vector3.Lerp(targetTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            targetTransform.anchoredPosition = Vector2.Lerp(targetTransform.anchoredPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // 最終位置とスケールを設定
        targetTransform.localScale = targetScale;
        targetTransform.anchoredPosition = targetPosition;

        // 画像変更
        targetImage.sprite = targetSprite;
    }

    // アニメーション処理
    private System.Collections.IEnumerator LevelUiAnimateToState(Vector3 targetScale, Vector3 targetPosition)
    {
        while (Vector3.Distance(LevelUiRectTransform.localScale, targetScale) > 0.01f ||
               Vector3.Distance(LevelUiRectTransform.localPosition, targetPosition) > 0.01f)
        {
            LevelUiRectTransform.localScale = Vector3.Lerp(LevelUiRectTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            LevelUiRectTransform.localPosition = Vector3.Lerp(LevelUiRectTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // 最終位置とスケールを確定
        LevelUiRectTransform.localScale = targetScale;
        LevelUiRectTransform.localPosition = targetPosition;
    }


}
