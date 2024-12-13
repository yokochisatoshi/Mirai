using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class short_needle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Transform myTransform = this.transform;


        Vector3 worldAngle = myTransform.eulerAngles;
        worldAngle.x = 0.0f;
        worldAngle.y = 0.0f;
        worldAngle.z = PlayerData.Instance.nTime / (-2.0f); // //time=60で30度回転なので60/30で2がマジックナンバー
        myTransform.eulerAngles = worldAngle;
    }
}
