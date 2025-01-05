using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    List<Material> childMr = new List<Material>();    // 全ての子オブジェクトのマテリアル格納してたらいいな

    public enum human_state // 人の状態
    {
        normal,         // ノーマル状態
        eat,            // 食事状態
        brainwashing,   // 洗脳(敵必殺)
        allyBrainwashing,   // 洗脳(味方必殺)
        Destroy,        // 退店
    }

    // 好物は出店している店の中からランダムで設定される
    private Store.food_type favorite;
    Vector3 pos;
    public float speed;
    GameObject ManageData;
    PlayerData script;
    GameObject child;

    bool bCanStore = false;

    int state = (int)human_state.normal;        // 人の状態(仮で初期はnormal)
    int eatCunt = 0;                            // 食事時間カウンタ
    public int eatTime;                         // 食事にかかる時間
    public int DestroyTime;                     // 消滅するまでの時間         
    public float speedUpBuf;                         // 食事にかかる時間
    public float speedDownDeBuf;                     // 消滅するまでの時間     
    public int addMoneyVal = 200;

    MeshRenderer mr;          // 透明化用

    GameObject EnemyTarget;
    GameObject AllyTarget;

    public bool speedUp = false;
    public bool speedDown = false;
    float speedBuf = 1.0f;
    // Start is called before the first frame update
    void Start()
    {

        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

        mr = GetComponent<MeshRenderer>();      // 透明化用(マテリアル情報取得？)

        // 出現している店をすべて取得
        GameObject[] StoreObjects = GameObject.FindGameObjectsWithTag("Store");     // 存在するStoreタグを持っているオブジェクトを配列に格納

        // 候補のなかから好物をランダムに設定
        if (StoreObjects.Length != 0)
        {
            int num = Random.Range(0, StoreObjects.Length);
            Store storeCs = StoreObjects[num].GetComponent<Store>();
            favorite = storeCs.GetFoodType();
        }

        child = transform.Find("favorite").gameObject;

        GetAllChildMr();        // 全ての子オブジェクトのマテリアルを取得して格納
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        pos = transform.position;

        // とりあえずY座標が一定以下なら消す
        if (this.transform.position.y < -1.0f)
        {
            Destroy(this.gameObject);
        }

        switch (state)
        {
            case (int)human_state.normal:
                // 移動処理(正面に移動)
                Moveforward();
                break;
            case (int)human_state.eat:          // 食事中
                eatCunt++;
                if (eatCunt > eatTime)
                { // 一定時間食事したら
                    //Debug.Log("unnti");
                    eatCunt = 0;
                    state = (int)human_state.Destroy;                               // 退店状態に遷移
                    if(this.gameObject.transform.position.z > 0)
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0); // プレイヤーを出口に向ける
                    }
                    else
                    {
                        this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0); // プレイヤーを出口に向ける
                    }
                    
                }
                break;
            case (int)human_state.Destroy:      // 退店状態
                // 移動処理(正面に移動)
                Moveforward();

                for (int i = 0; i < childMr.Count; i++)
                {
                    childMr[i].color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));
                }

                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));  // 透明にしていく
                Destroy(this.gameObject, DestroyTime);                                                           // 一定時間経ったら殺す
                break;
            case (int)human_state.brainwashing: // 洗脳状態
                this.transform.LookAt(EnemyTarget.transform);   // 目的の店の方向を向く
                // 正面に移動
                Moveforward();
                break;
            case (int)human_state.allyBrainwashing: // 洗脳状態
                this.transform.LookAt(AllyTarget.transform);   // 目的の店の方向を向く
                // 正面に移動
                Moveforward();
                break;
        }
    }


    // プレイヤー側の当たり判定
    void OnCollisionEnter(Collision collision)
    {
        if (state == (int)human_state.normal)
        {

            // 壁
            if (collision.gameObject.tag == "wall")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (state == (int)human_state.normal)
        {

            // 標識？
            if (other.gameObject.tag == "backMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "leftMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "rightMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "frontMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = true;
                // Debug.Log("hitfront");
            }

            if (other.gameObject.tag == "Store" && bCanStore == true)
            { // 店に当たったら
                state = (int)human_state.eat;       // 食事状態に遷移
                script.AddMoney(addMoneyVal);       // お金加算
                script.AddScore(150);               // スコア加算
            }
            else if (other.gameObject.tag == "EnemyStore" && bCanStore == true)
            { // 敵の店当たったら
                state = (int)human_state.eat;       // 食事状態に遷移
            }
        }

        if (state == (int)human_state.brainwashing && other.gameObject.name == EnemyTarget.name)
        { // 洗脳状態かつ目的の敵の店に当たったら
            //Debug.Log("e store");
            state = (int)human_state.eat;       // 食事状態に遷移
        }

        if (state == (int)human_state.allyBrainwashing && other.gameObject.name == AllyTarget.name)
        { // 洗脳状態かつ目的の味方の店に当たったら
            //Debug.Log("e store");
            script.AddMoney(addMoneyVal);       // お金加算
            script.AddScore(150);               // スコア加算
            state = (int)human_state.eat;       // 食事状態に遷移
        }
    }

    // 状態遷移関数
    public void SetState(human_state _state)
    {
        state = (int)_state;
        if (_state == human_state.brainwashing) child.GetComponent<favorite>().SetBrainwashingTex();
        if (_state == human_state.allyBrainwashing) child.GetComponent<favorite>().SetFavoriteTex();
    }

    // 状態取得関数
    public int GetState()
    {
        return state;
    }

    // 敵の向かう店セット関数
    public void SetTargetEnemyStore(GameObject _target)
    {
        EnemyTarget = _target;
    }
    public void SetTargetAllyStore(GameObject _target)
    {
        AllyTarget = _target;
    }

    public Store.food_type GetFavoriteFood()
    {
        return favorite;
    }
    public void SetFavoriteFood(Store.food_type _food)
    {
        favorite = _food;
    }

    // 子マテリアル取得関数
    public void GetAllChildMr()
    {
        List<GameObject> childbjects = new List<GameObject>();

        // 親オブジェクトのTransformからすべての子オブジェクト（子の子の子の...）を取得
        GetChildren(this.gameObject, ref childbjects);

        for (int i = 0; i < childbjects.Count; i++)
        {
            // 子オブジェクトのTransformを取得
            Transform childTransform = childbjects[i].GetComponent<Transform>();

            if (childTransform != null)
            {
                // 子オブジェクトのRendererを取得
                Renderer childRenderer = childTransform.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    if (childbjects[i].GetComponent<SkinnedMeshRenderer>() != null)   // 適当
                    {
                        var mat = Resources.Load<Material>("Materials/mat");
                        var mats = childbjects[i].GetComponent<SkinnedMeshRenderer>().materials;
                        for (int j = 0; j < childbjects[i].GetComponent<SkinnedMeshRenderer>().materials.Length; j++)
                        {
                            childMr.Add(mats[j]);
                        }
                    }
                    else
                    {
                        childMr.Add(childRenderer.material);
                    }

                    // 子オブジェクトのMaterialを格納
                    //childMr.Add(childRenderer.material);
                }
            }
        }
    }

    //子要素を取得してリストに追加
    public void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //子要素がいなければ終了
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }

    public void HitLv3(Store.food_type food)
    {
        favorite= food;
        child.GetComponent<favorite>().SetFavoriteTex();

    }

    void Moveforward()
    {
        if(speedUp == true && speedDown == false)
        {
            speedBuf = speedUpBuf;
        }
        else if(speedUp == false && speedDown == true)
        {
            speedBuf = speedDownDeBuf;
        }
        else if (speedUp == true && speedDown == true)
        {
            speedBuf = speedDownDeBuf + speedUpBuf;
        }
        else
        {
            speedBuf = 1.0f;
        }

        pos += transform.forward * speed * speedBuf;
        transform.position = pos;
    }
}