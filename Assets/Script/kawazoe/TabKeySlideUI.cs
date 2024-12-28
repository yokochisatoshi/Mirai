using UnityEngine;

public class TabKeySlideUI : MonoBehaviour
{
    public RectTransform panel;  // 対象のUI Panel
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
        // Tabキーでトグル
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;
        }

        // スライドアニメーション
        Vector2 targetPosition = isOpen ? openPosition : closedPosition;
        panel.anchoredPosition = Vector2.MoveTowards(panel.anchoredPosition, targetPosition, slideSpeed * Time.deltaTime);
    }
}
