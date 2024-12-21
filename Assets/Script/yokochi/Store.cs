using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public int cooltime = 100;      // 必殺技のクールタイム
    public int count = 0;           // クールタイムのカウンタ
    public enum food_type
    {
        misokatu,
        uirou,
        BigEye,
    }

    public food_type food;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > cooltime)
        { // cooltime分時間が経ったら
            count = 0;
        }
    }

    public food_type GetFoodType()
    {
        return food;
    }
}
