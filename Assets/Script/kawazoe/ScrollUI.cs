using UnityEngine;

public class ScrollUI : MonoBehaviour
{
    public RectTransform uiElement; // スクロールさせたいUI
    public float scrollSpeed = 200f; // スクロール速度
    public float resetThreshold = -1000f; // 左端に到達したときの位置
    public float startOffset = 1000f; // 再出現時の位置（右端）

    void Update()
    {
        // 現在位置を左に移動
        uiElement.anchoredPosition += Vector2.left * scrollSpeed * Time.deltaTime;

        // 指定した位置を超えたらリセット
        if (uiElement.anchoredPosition.x < resetThreshold)
        {
            uiElement.anchoredPosition = new Vector2(startOffset, uiElement.anchoredPosition.y);
        }
    }
}
