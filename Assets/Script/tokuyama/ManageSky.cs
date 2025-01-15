using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSky : MonoBehaviour
{

    public Material skybox1;
    public Material skybox2;
    public Material skybox3;

    public GameObject Light;
    private Color color;
    private Vector3 VecRotation = new Vector3(90f, 0, 0);
    bool bUseSky2 = false;
    bool bUseSky3 = false;
    bool bUseLight = false;

    //‚Ï‚í‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ 
    public GameObject PointLight0;
    public GameObject PointLight1;
    public GameObject PointLight2;
    public GameObject PointLight3;
    public GameObject PointLight4;
    public GameObject PointLight5;
    public GameObject PointLight6;
    public GameObject PointLight7;
    public GameObject PointLight8;
    public GameObject PointLight9;
    public GameObject PointLight10;
    public GameObject PointLight11;
    public GameObject PointLight12;
    public GameObject PointLight13;
    public GameObject PointLight14;
    public GameObject PointLight15;
    public GameObject PointLight16;

    private float ColorSpeed = 0.004f;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = skybox1;
        color = Color.black;

     //‚Ï‚í‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ 
     PointLight0.SetActive(false);
     PointLight1.SetActive(false);
     PointLight2.SetActive(false);
     PointLight3.SetActive(false);
     PointLight4.SetActive(false);
     PointLight5.SetActive(false);
     PointLight6.SetActive(false);
     PointLight7.SetActive(false);
     PointLight8.SetActive(false);
     PointLight9.SetActive(false);
     PointLight10.SetActive(false);
     PointLight11.SetActive(false);
     PointLight12.SetActive(false);
     PointLight13.SetActive(false);
     PointLight14.SetActive(false);
     PointLight15.SetActive(false);
     PointLight16.SetActive(false);

        color = Light.GetComponent<Light>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerData.Instance.nTime>=110 && bUseSky2==false)
        {
            RenderSettings.skybox = skybox2;
            if(Light.transform.localRotation.x<=0.7f)
            {
                Light.transform.Rotate(new Vector3(0.4f, 0, 0));
            }
            else
            {
                bUseSky2 = true;
            }
        }


        if (PlayerData.Instance.nTime >= 230 && bUseSky3 == false)
        {
            RenderSettings.skybox = skybox3;
            if (color.r>=0.0f)
            {
                Light.transform.Rotate(new Vector3(0.4f, 0, 0));
                color= new Color(color.r - ColorSpeed, color.g - ColorSpeed, color.b - ColorSpeed);
                Light.GetComponent<Light>().color = color;
            }
            else
            {
                bUseSky3 = true;
            }
           
        }

        //if (bUseSky2 == true)
        //{
        //    Light.transform.rotation = Quaternion.Euler(VecRotation);
        //    Debug.Log("?");

        //}


        if (PlayerData.Instance.nTime >= 245 && bUseLight == false)
        {
            //‚Ï‚í‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ ‚ 
            PointLight0.SetActive(true);
            PointLight1.SetActive(true);
            PointLight2.SetActive(true);
            PointLight3.SetActive(true);
            PointLight4.SetActive(true);
            PointLight5.SetActive(true);
            PointLight6.SetActive(true);
            PointLight7.SetActive(true);
            PointLight8.SetActive(true);
            PointLight9.SetActive(true);
            PointLight10.SetActive(true);
            PointLight11.SetActive(true);
            PointLight12.SetActive(true);
            PointLight13.SetActive(true);
            PointLight14.SetActive(true);
            PointLight15.SetActive(true);
            PointLight16.SetActive(true);

            bUseLight = true;
        }


    }
}
