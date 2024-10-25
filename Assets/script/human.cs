using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 移動処理(正面に移動)
        Vector3 pos = transform.position;
        pos += transform.forward * speed ;
        transform.position = pos;

        // とりあえずY座標が一定以下なら消す
        if(this.transform.position.y < 1.5)
        {
            Destroy(this.gameObject);
        }
    }

    // プレイヤー側の当たり判定
    void OnCollisionEnter(Collision collision)
    {
        // 壁
        if (collision.gameObject.tag == "wall")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // 標識？
        if (other.gameObject.tag == "backMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (other.gameObject.tag == "leftMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (other.gameObject.tag == "rightMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (other.gameObject.tag == "frontMarker")
        {
            this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
            Debug.Log("hitfront");
        }
    }
}
