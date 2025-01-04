using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class StoreLevelUi : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TextMeshProUGUI levelText;
    public int level = 1;  // 現在のレベル
    public int maxLevel = 3; // 最大レベル

    public float hoverScale; // ホバー時のスケール
    public Vector2 hoverPositionOffset; // ホバー時の位置オフセット
    public float animationSpeed = 10f; // アニメーション速度

    private Vector3 originalScale; // 初期スケール
    private Vector2 originalPosition; // 初期位置

    private RectTransform rectTransform; // オブジェクトのRectTransform

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // 初期位置とスケールを保存
        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.localPosition;

        // レベル表示を更新
        UpdateLevelText();
    }

    void Update()
    {
        // 常に最新のレベルを表示
        levelText.text = level.ToString();
    }

    // レベルアップボタンが押されたときに呼び出す
    public void OnLevelUpButtonClicked()
    {
        if (level < maxLevel)
        {
            level++;
            UpdateLevelText();
        }
    }

    // ホバー時に呼び出される
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(originalScale * hoverScale, originalPosition + hoverPositionOffset));
    }

    // ホバー解除時に呼び出される
    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines(); // アニメーションをリセット
        StartCoroutine(AnimateToState(originalScale, originalPosition));
    }

    // アニメーション処理
    private IEnumerator AnimateToState(Vector3 targetScale, Vector3 targetPosition)
    {
        while (Vector3.Distance(rectTransform.localScale, targetScale) > 0.01f ||
               Vector3.Distance(rectTransform.localPosition, targetPosition) > 0.01f)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale, targetScale, Time.deltaTime * animationSpeed);
            rectTransform.localPosition = Vector3.Lerp(rectTransform.localPosition, targetPosition, Time.deltaTime * animationSpeed);
            yield return null;
        }

        // 最終位置とスケールを確定
        rectTransform.localScale = targetScale;
        rectTransform.localPosition = targetPosition;
    }

    // レベルテキストを更新
    private void UpdateLevelText()
    {
        levelText.text = level.ToString();
    }
}
