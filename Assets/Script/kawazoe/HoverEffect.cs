using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform targetTransform;    // 拡大・移動する対象
    public Image targetImage;                // 画像切り替え対象
    public Sprite hoverSprite;               // ホバー時の画像
    public Sprite defaultSprite;             // デフォルト画像
    public float scaleFactor;                // 拡大率
    public Vector2 moveOffset;               // 移動量
    public GameObject ScaleIncreaseButton;   // 表示するボタン
    public GameObject SpecialButton;
    public float animationSpeed = 10f;       // アニメーション速度

    private Vector3 originalScale;
    private Vector2 originalPosition;

    void Start()
    {
        // 初期値を記録
        originalScale = targetTransform.localScale;
        originalPosition = targetTransform.anchoredPosition;

        // 初期状態でボタンを非表示
        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(originalScale * scaleFactor, originalPosition + moveOffset, hoverSprite, true));

        targetTransform.transform.SetAsLastSibling();

        ScaleIncreaseButton.SetActive(true);
        SpecialButton.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(originalScale, originalPosition, defaultSprite, false));

        ScaleIncreaseButton.SetActive(false);
        SpecialButton.SetActive(false);
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
}
