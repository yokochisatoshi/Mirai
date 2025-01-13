using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class favorite : MonoBehaviour
{
    [SerializeField] Texture MisokatuTex = default;
    [SerializeField] Texture UirouTex = default;
    [SerializeField] Texture HitsumabushiTex = default;
    [SerializeField] Texture TebasakiTex = default;
    [SerializeField] Texture TaiwanRamenTex = default;
    [SerializeField] Texture KishimenTex = default;

    [SerializeField] Texture BrainwashingTex = default;
    Texture texture;
    Material material;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        SetFavoriteTex();
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
    }

    public void SetFavoriteTex()
    {
        // material取得
        material = this.GetComponent<MeshRenderer>().material;
        // テクスチャの取得
        texture = material.GetTexture("_MainTex");

        obj = transform.root.gameObject;

        Debug.Log(obj.GetComponent<human>().GetFavoriteFood());
        switch (obj.GetComponent<human>().GetFavoriteFood())
        {
            case Store.food_type.Misokatu:
                // テクスチャの変更
                material.SetTexture("_MainTex", MisokatuTex);
                break;
            case Store.food_type.Uirou:
                // テクスチャの変更
                material.SetTexture("_MainTex", UirouTex);
                break;
            case Store.food_type.Hitsumabushi:
                // テクスチャの変更
                material.SetTexture("_MainTex", HitsumabushiTex);
                break;
            case Store.food_type.Tebasaki:
                // テクスチャの変更
                material.SetTexture("_MainTex", TebasakiTex);
                break;
            case Store.food_type.TaiwanRamen:
                // テクスチャの変更
                material.SetTexture("_MainTex", TaiwanRamenTex);
                break;
            case Store.food_type.Kishimen:
                // テクスチャの変更
                material.SetTexture("_MainTex", KishimenTex);
                break;
        }
    }

    public void SetBrainwashingTex()
    {
        // material取得
        material = this.GetComponent<MeshRenderer>().material;

        // テクスチャの取得
        texture = material.GetTexture("_MainTex");

        // テクスチャの変更
        material.SetTexture("_MainTex", BrainwashingTex);

        Debug.Log("tanomu~");
    }
}