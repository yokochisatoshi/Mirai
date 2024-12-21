using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveVal = 5.0f;    // カメラのスピード
    bool ableMove;                  // カメラ移動可能フラグ

    // Start is called before the first frame update
    void Start()
    {
        ableMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableMove == true)
        {
            Vector3 pos = transform.position;
            float val = Input.GetAxis("Mouse ScrollWheel");
            pos.x += val * moveVal;

            // x座標が-5未満にならないように制限
            if (pos.x < -5)
            {
                pos.x = -5;
            }

            // x座標が130以上にならないように制限
            if (pos.x > 130)
            {
                pos.x = 130;
            }


            transform.position = pos;
        }
    }
}