using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartManager : MonoBehaviour
{
    //âπånÇÃÇ‡ÇÃ
    AudioSource audioSource;
    //public AudioClip BGM00;
    //public AudioClip SESupo;
    //public AudioClip SEStart;
    bool bUseSE00=false;
    bool bUseSE01=false;
    bool bUseSEStart=false;

    //
    public Image WhitePanel;
    private float fFadePanel = 1.0f;
    //
    public GameObject GameImage;
    public GameObject StartImage;
    private bool bFinish = false;
    private int nTimeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        WhitePanel.color = new Color(WhitePanel.color.r, WhitePanel.color.g, WhitePanel.color.b, 1.0f);
        GameImage.transform.localScale = new Vector3(0, 0, 0);
        StartImage.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bFinish == false)
        {
            fFadePanel -= 0.008f;
            WhitePanel.color = new Color(WhitePanel.color.r, WhitePanel.color.g, WhitePanel.color.b, fFadePanel);

            if (fFadePanel <= 0)
            {
                if (GameImage.transform.localScale.x <= 5)
                {
                    GameImage.transform.localScale = new Vector3(GameImage.transform.localScale.x + 0.3f, GameImage.transform.localScale.y + 0.15f, GameImage.transform.localScale.z);
                    if(bUseSE00==false)
                    {
                        bUseSE00 = true;
                        //audioSource.PlayOneShot(SESupo);
                    }
                }
                else
                {
                    if (StartImage.transform.localScale.x <= 5)
                    {
                        StartImage.transform.localScale = new Vector3(StartImage.transform.localScale.x + 0.4f, StartImage.transform.localScale.y + 0.2f, StartImage.transform.localScale.z);
                    }
                    else
                    {
                        if (bUseSE01 == false)
                        {
                            bUseSE01 = true;
                            //audioSource.PlayOneShot(SESupo);
                        }
                        nTimeCount++;
                        if(nTimeCount>=50)
                        {
                            GameImage.transform.position = new Vector3(GameImage.transform.position.x - 40.0f, GameImage.transform.position.y, GameImage.transform.position.z);
                            StartImage.transform.position = new Vector3(StartImage.transform.position.x + 40.0f, StartImage.transform.position.y, StartImage.transform.position.z);
                            if (GameImage.transform.position.x >= 3000)
                            {
                                bFinish = true;
                            }
                            //ÉQÅ[ÉÄäJén
                            if(PlayerData.Instance.bGameStart==false)
                            {
                                //audioSource.PlayOneShot(SEStart);
                            }
                           
                            PlayerData.Instance.bGameStart = true;
                        }
                        
                        
                    }

                }
            }
        }
    }
}
