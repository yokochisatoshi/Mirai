using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
<<<<<<< Updated upstream
    public enum human_state // 人の状態
    {
        normal,     // ノーマル状態
        eat,        // 食事状態
        Destroy,    // 退店
    }



    public float speed;
    GameObject ManageData;
    PlayerData script;
=======
>>>>>>> Stashed changes

    public enum human_state // 人の状態
    {
        normal,     // ノーマル状態
        eat,        // 食事状態
        Destroy,    // 退店
    }

    public float speed;                         // 歩くスピード
    public PlayerData playerData;
    bool bCanStore = false;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    int state = (int)human_state.normal;        // 人の状態(仮で初期はnormal)
    int eatCunt = 0;                            // 食事時間カウンタ
    public int eatTime;                         // 食事にかかる時間
    public int DestroyTime;                     // 消滅するまでの時間         

    MeshRenderer mr;          // 透明化用
<<<<<<< Updated upstream


    // Start is called before the first frame update
    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

=======
    // Start is called before the first frame update
    void Start()
    {
>>>>>>> Stashed changes
        mr = GetComponent<MeshRenderer>();      // 透明化用(マテリアル情報取得？)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
<<<<<<< Updated upstream
        // 移動処理(正面に移動)
        Vector3 pos = transform.position;
       

        // とりあえずY座標が一定以下なら消す
        if(this.transform.position.y < -1.0f)
=======
        Vector3 pos = transform.position;       // プレイヤーの座標取得

        // とりあえずY座標が一定以下なら消す
        if (this.transform.position.y < 1.5)
>>>>>>> Stashed changes
        {
            Destroy(this.gameObject);
        }

<<<<<<< Updated upstream
=======
        // プレイヤー状態
>>>>>>> Stashed changes
        switch (state)
        {
            case (int)human_state.normal:
                // 移動処理(正面に移動)
                pos += transform.forward * speed;
                transform.position = pos;
                break;
            case (int)human_state.eat:          // 食事中
<<<<<<< Updated upstream
                eatCunt++;
                if (eatCunt > eatTime)
                { // 一定時間食事したら
                    Debug.Log("unnti");
=======
                eatCunt++;                  
                if(eatCunt > eatTime)
                { // 一定時間食事したら
>>>>>>> Stashed changes
                    eatCunt = 0;
                    state = (int)human_state.Destroy;                               // 退店状態に遷移
                    this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0); // プレイヤーを出口に向ける
                }
                break;
            case (int)human_state.Destroy:      // 退店状態
                // 移動処理(正面に移動)
                pos += transform.forward * speed;
                transform.position = pos;

<<<<<<< Updated upstream
                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));  // 透明にしていく
                Destroy(this.gameObject, DestroyTime);                                                           // 一定時間経ったら殺す
                break;
        }



=======
                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 1));  // 透明にしていく
                Destroy(this.gameObject,DestroyTime);                                                           // 一定時間経ったら殺す
                break;
        }
>>>>>>> Stashed changes
    }




    // プレイヤー側の当たり判定
    void OnCollisionEnter(Collision collision)
<<<<<<< Updated upstream
    {
        if (state == (int)human_state.normal)
        {

            // 壁
=======
    { // 通常状態なら
        // 壁
        if (state == (int)human_state.normal)
        {
>>>>>>> Stashed changes
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
<<<<<<< Updated upstream
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
                Debug.Log("hitfront");
            }

            if (other.gameObject.tag == "Store" && bCanStore == true)
            {
                Debug.Log("store");
                // Destroy(this.gameObject);
                state = (int)human_state.eat;       // 食事状態に遷移
                script.AddMoney(150);

            }
        }
=======
        { // 通常状態なら
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
                Debug.Log("hitfront");
            }
            // 店
            if (other.gameObject.tag == "Store" && bCanStore == true)
            {
                Debug.Log("store");
                state = (int)human_state.eat;       // 食事状態に遷移
                playerData.AddMoney(150);

            }
        } 
>>>>>>> Stashed changes
    }
}
