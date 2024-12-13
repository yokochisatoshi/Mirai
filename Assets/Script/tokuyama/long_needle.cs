using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class long_needle : MonoBehaviour
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
        worldAngle.z = PlayerData.Instance.nTime * (-6.0f) ; //360°/60分で6がマジックナンバー
        myTransform.eulerAngles = worldAngle; 

    }
}
