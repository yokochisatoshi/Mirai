using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float moveVal = 5.0f;    // �J�����̃X�s�[�h
    bool ableMove;                  // �J�����ړ��\�t���O

    // Start is called before the first frame update
    void Start()
    {
        ableMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
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
