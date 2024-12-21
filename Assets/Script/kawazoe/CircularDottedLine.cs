using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CircularDottedLine : MonoBehaviour
{
    public int segments = 50;       // 円を構成する点の数
    public float radius = 5f;       // 円の半径
    public float gapSize = 0.3f;    // 点線の間隔（割合で指定）
    public Color lineColor; // 点線の色
    public float lineWidth = 0.5f;  // 線の太さ

    private LineRenderer lineRenderer;

    void Start()
    {
        // LineRendererコンポーネントを追加
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // LineRendererの基本設定
        lineRenderer.positionCount = segments + 1;
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.loop = true;

        // 親オブジェクトが持つタグに基づいて色を変更する
        if (transform.parent != null)
        {
            // 親オブジェクトのタグが"HousePrefab"か確認
            if (transform.parent.CompareTag("Store"))
            {
                // 親オブジェクトが"HousePrefab"タグの場合、色を青に変更
                lineColor = Color.blue;
                ChangeLineColor(Color.blue);
                Debug.Log("ao");
            }
            else
            {
                // その他の場合、色を赤に変更
                lineColor = Color.red;
                ChangeLineColor(Color.red);
                Debug.Log("aka");
            }
        }

        // マテリアルを適用（透過対応）
        Material material = new Material(Shader.Find("Sprites/Default"));
        material.color = lineColor;
        lineRenderer.material = material;

        Vector3 center = transform.position;  // 空オブジェクトの位置を取得

        // 頂点を計算して設定
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i <= segments; i++)
        {
            float angle = i * Mathf.PI * 2 / segments;
            // 円の座標を計算して中心位置を加える
            points[i] = new Vector3(Mathf.Cos(angle) * radius, 0.7f, Mathf.Sin(angle) * radius) + center;
        }
        lineRenderer.SetPositions(points);

        // 点線効果を設定
        SetDottedEffect();
    }

    void Update()
    {
        // 親の中心を軸に回転させる
        transform.RotateAround(transform.parent.position, Vector3.up, 30f * Time.deltaTime);
    }

    void SetDottedEffect()
    {
        // アルファ値で点線の効果を作る
        Gradient gradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[1];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[segments + 1];

        // 色を設定（単色）
        colorKey[0] = new GradientColorKey(lineColor, 0f);

        // 点線の間隔をアルファ値で設定
        for (int i = 0; i <= segments; i++)
        {
            float t = (float)i / segments;
            alphaKey[i] = new GradientAlphaKey((t % gapSize) < (gapSize / 2) ? 1f : 0f, t);
        }

        //// グラデーションを設定
        //gradient.SetKeys(colorKey, alphaKey);
        //lineRenderer.colorGradient = gradient;
    }

    // LineRendererの色を変更するメソッド
    void ChangeLineColor(Color color)
    {
        if (lineRenderer != null)
        {
            lineRenderer.startColor = color;  // 始点の色
            lineRenderer.endColor = color;    // 終点の色
        }
    }
}
