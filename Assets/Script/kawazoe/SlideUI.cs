using UnityEngine;
using UnityEngine.EventSystems;

public class SlideUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform panel;  // 対象のUI Panel
    public GameObject uiTrigger;  // トリガーとなるUI要素（非表示にする）
    public float slideSpeed = 500f;  // スライド速度
    private bool isOpen = false;  // パネルが開いているか
    private Vector2 closedPosition;  // 閉じたときの位置
    private Vector2 openPosition;  // 開いたときの位置

    void Start()
    {
        // 初期位置設定
        closedPosition = panel.anchoredPosition;
        openPosition = closedPosition + new Vector2(panel.rect.width, 0); // 横幅分移動
    }

    void Update()
    {
        // スライドアニメーション
        Vector2 targetPosition = isOpen ? openPosition : closedPosition;
        panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
    }

    // マウスがUIトリガーに入ったとき
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;  // パネルを開く
        uiTrigger.SetActive(false);  // トリガーUIを非表示
    }

    // マウスがUIトリガーから出たとき
    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;  // パネルを閉じる
        uiTrigger.SetActive(true);  // トリガーUIを表示
    }
}
