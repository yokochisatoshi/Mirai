using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{

    bool bLevel2 = false;
    bool bLevel3 = false;
    //
    public GameObject Cam;
    public GameObject AnotherCamPos;
    bool bMoveCam = false;
    public GameObject AnotherCamPos2;
    Vector3 OriginCamPos;
    Vector3 OriginCamRot;
    //
    public GameObject StoreUI;
    public GameObject UI00;
    public GameObject UI01;
    public GameObject UI02;
    public GameObject UI03;
    public GameObject UI04;
    public GameObject UI05;
    public GameObject UI06;
    //
    public GameObject Earth;
    float speed = 0.6f;
    //
    public GameObject Range;
    int nTime = 0;
    bool bBig = false;
    //
    public Image PanelWhite;
    public Image PanelBlack;
    //
    //音系のもの
    AudioSource audioSource;
    public AudioClip SE00;
    //
    public GameObject Lv2;
    public GameObject Lv3;
    Vector3 OriginScaleLv2;
    //Vector3 BigScaleLv2;
    // Start is called before the first frame update
    void Start()
    {
        //音系のもの
        audioSource = GetComponent<AudioSource>();
        //
        OriginScaleLv2=Lv2.transform.localScale;
        Lv2.transform.localScale = new Vector3(0,0,0);
        Lv3.transform.localScale = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        //Scoreに応じてステージレベルが変化する処理

        if (PlayerData.Instance.nCurrentStage == 0 && PlayerData.Instance.nScore >= 200)       //元々は　Instance.nScore >= 1000
        {
            PlayerData.Instance.nCurrentStage = 1;
            PlayerData.Instance.bGameStart = false;
           bLevel2 = true;
            OriginCamPos=Cam.transform.position;
            OriginCamRot=Cam.transform.localEulerAngles;
        }

        if (PlayerData.Instance.nCurrentStage == 1 && PlayerData.Instance.nScore >= 1200)       //元々は　確かInstance.nScore >= 2000
        {
            PlayerData.Instance.nCurrentStage = 2;
            PlayerData.Instance.bGameStart = false;
            bLevel3 = true;
            OriginCamPos = Cam.transform.position;
            OriginCamRot = Cam.transform.localEulerAngles;
        }
        //
        if (Input.GetKeyUp(KeyCode.Return))
        {
            PlayerData.Instance.bGameStart = true;
        }

        //
        if(bLevel2)
        {
            Cam.transform.localEulerAngles = new Vector3(0, 0, 0);
            if(bMoveCam==false)
            {
                bMoveCam = true;
                Cam.transform.position = AnotherCamPos.transform.position;
                //
                Color color = PanelBlack.color;
                color.a = 1.0f;
                PanelBlack.color = color;
            }
            //
            StoreUI.SetActive(false);
            UI00.SetActive(false);
            UI01.SetActive(false);
            UI02.SetActive(false);
            UI03.SetActive(false);
            UI04.SetActive(false);
            UI05.SetActive(false);
            UI06.SetActive(false);
            //
            if(Cam.transform.position.z <= AnotherCamPos2.transform.position.z)
            {
                Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z + speed);
            }
            else
            {
                if(bBig==false)
                {
                    nTime++;
                    if(nTime>=120)
                    {
                        bBig = true;
                        Range.transform.localScale = new Vector3(Range.transform.localScale.x * 6.0f, Range.transform.localScale.y * 6.0f, Range.transform.localScale.z * 6.0f);
                        Color color = PanelWhite.color;
                        color.a = 1.0f;
                        PanelWhite.color = color;
                        audioSource.PlayOneShot(SE00);
                        Lv2.transform.localScale=new Vector3(OriginScaleLv2.x*10, OriginScaleLv2.y*10, OriginScaleLv2.z*10);
                    }
                }
                else
                {
                    if (nTime >= 120)
                    {
                        float perY = OriginScaleLv2.y / OriginScaleLv2.x;
                        float perZ = OriginScaleLv2.z / OriginScaleLv2.x;
                        if (Lv2.transform.localScale.x>=OriginScaleLv2.x)
                        {
                            Lv2.transform.localScale = new Vector3(Lv2.transform.localScale.x - 0.6f, Lv2.transform.localScale.y - 0.6f * perY, Lv2.transform.localScale.z - 0.6f * perZ);
                        }
                        else
                        {
                            nTime++;
                            if(nTime>=240)
                            {
                                Cam.transform.position = OriginCamPos;
                                Cam.transform.localEulerAngles=OriginCamRot;
                                Lv2.SetActive(false);
                                PlayerData.Instance.bGameStart = true;
                                bLevel2 = false;//
                                //
                                StoreUI.SetActive(true);
                                UI00.SetActive(true);
                                UI01.SetActive(true);
                                UI02.SetActive(true);
                                UI03.SetActive(true);
                                UI04.SetActive(true);
                                UI05.SetActive(true);
                                UI06.SetActive(true);
                                //
                                bMoveCam = false;
                                bBig=false;
                                nTime = 0;
                            }
                        }
                       
                    }
                }

                
            }




            Color color2 = PanelWhite.color;
            color2.a -= 0.01f;
            PanelWhite.color = color2;

            Color color3 = PanelBlack.color;
            color3.a -= 0.01f;
            PanelBlack.color = color3;
        }

        if (bLevel3)
        {
            Cam.transform.localEulerAngles = new Vector3(0, 0, 0);
            if (bMoveCam == false)
            {
                bMoveCam = true;
                Cam.transform.position = AnotherCamPos.transform.position;
                //
                Color color = PanelBlack.color;
                color.a = 1.0f;
                PanelBlack.color = color;
            }
            //
            StoreUI.SetActive(false);
            UI00.SetActive(false);
            UI01.SetActive(false);
            UI02.SetActive(false);
            UI03.SetActive(false);
            UI04.SetActive(false);
            UI05.SetActive(false);
            UI06.SetActive(false);
            //
            if (Cam.transform.position.z <= AnotherCamPos2.transform.position.z)
            {
                Cam.transform.position = new Vector3(Cam.transform.position.x, Cam.transform.position.y, Cam.transform.position.z + speed);
            }
            else
            {
                if (bBig == false)
                {
                    nTime++;
                    if (nTime >= 120)
                    {
                        bBig = true;
                        Range.transform.localScale = new Vector3(Range.transform.localScale.x * 2.5f, Range.transform.localScale.y * 2.5f, Range.transform.localScale.z * 2.5f);
                        Color color = PanelWhite.color;
                        color.a = 1.0f;
                        PanelWhite.color = color;
                        audioSource.PlayOneShot(SE00);
                        Lv3.transform.localScale = new Vector3(OriginScaleLv2.x * 10, OriginScaleLv2.y * 10, OriginScaleLv2.z * 10);
                    }
                }
                else
                {
                    if (nTime >= 120)
                    {
                        float perY = OriginScaleLv2.y / OriginScaleLv2.x;
                        float perZ = OriginScaleLv2.z / OriginScaleLv2.x;
                        if (Lv3.transform.localScale.x >= OriginScaleLv2.x)
                        {
                            Lv3.transform.localScale = new Vector3(Lv3.transform.localScale.x - 0.6f, Lv3.transform.localScale.y - 0.6f * perY, Lv3.transform.localScale.z - 0.6f * perZ);
                        }
                        else
                        {
                            nTime++;
                            if (nTime >= 240)
                            {
                                Cam.transform.position = OriginCamPos;
                                Cam.transform.localEulerAngles = OriginCamRot;
                                Lv3.SetActive(false);
                                PlayerData.Instance.bGameStart = true;
                                bLevel3 = false;//
                                //
                                StoreUI.SetActive(true);
                                UI00.SetActive(true);
                                UI01.SetActive(true);
                                UI02.SetActive(true);
                                UI03.SetActive(true);
                                UI04.SetActive(true);
                                UI05.SetActive(true);
                                UI06.SetActive(true);
                            }
                        }

                    }
                }


            }

            Color color2 = PanelWhite.color;
            color2.a -= 0.01f;
            PanelWhite.color = color2;

            Color color3 = PanelBlack.color;
            color3.a -= 0.01f;
            PanelBlack.color = color3;
        }

    }
}
