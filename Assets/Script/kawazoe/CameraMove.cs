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
            transform.position = pos;
        }
    }
}