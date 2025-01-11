using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultSceneManage : MonoBehaviour
{

    public GameObject Cam;
    public GameObject FirstCube;
    public GameObject SecondCube;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Cam.transform.position.z>=SecondCube.transform.position.z)
        {
            Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z-0.1f);
        }
       
    }
}
