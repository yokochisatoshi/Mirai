using UnityEngine;

public class ImageResize : MonoBehaviour
{
    public RectTransform targetImage; // 拡大・縮小対象のImageのRectTransform
    public Vector2 maxSize = new Vector2(600, 600); // 最大サイズ
    public Vector2 minSize = new Vector2(100, 100); // 最小サイズ

    // サイズを大きくする
    public void IncreaseSize()
    {
        if (targetImage.sizeDelta.x < maxSize.x && targetImage.sizeDelta.y < maxSize.y)
        {
            Debug.Log("拡大します");
            targetImage.sizeDelta += new Vector2(50, 50); // 10x10ずつ拡大
        }
    }

    // サイズを小さくする
    public void DecreaseSize()
    {
        if (targetImage.sizeDelta.x > minSize.x && targetImage.sizeDelta.y > minSize.y)
        {
            targetImage.sizeDelta -= new Vector2(50, 50); // 10x10ずつ縮小
        }
    }
}
