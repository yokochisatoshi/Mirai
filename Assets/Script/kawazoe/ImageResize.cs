using UnityEngine;

public class ImageAutoResize : MonoBehaviour
{
    public RectTransform targetImage; // 拡大・縮小対象のImageのRectTransform
    public Vector2 maxSize = new Vector2(300, 300); // 最大サイズ
    public Vector2 minSize = new Vector2(100, 100); // 最小サイズ
    public float speed = 80f; // 拡大・縮小のスピード
    private bool isGrowing = true; // 拡大中か縮小中か

    void Update()
    {
        // 現在のサイズを取得
        Vector2 currentSize = targetImage.sizeDelta;

        if (isGrowing)
        {
            // 拡大
            currentSize += Vector2.one * speed * Time.deltaTime;
            if (currentSize.x >= maxSize.x || currentSize.y >= maxSize.y)
            {
                isGrowing = false; // 最大サイズに達したら縮小に切り替え
            }
        }
        else
        {
            // 縮小
            currentSize -= Vector2.one * speed * Time.deltaTime;
            if (currentSize.x <= minSize.x || currentSize.y <= minSize.y)
            {
                isGrowing = true; // 最小サイズに達したら拡大に切り替え
            }
        }

        // サイズを適用
        targetImage.sizeDelta = currentSize;
    }
}
