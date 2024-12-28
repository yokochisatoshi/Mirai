using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopManager : MonoBehaviour
{
    public GameObject Lv2Bigeye;
    public GameObject Lv2Misokatu;
    public GameObject Lv2EneStore;

    // Start is called before the first frame update
    void Start()
    {
        Lv2Bigeye.SetActive(false);
        Lv2Misokatu.SetActive(false);
        Lv2EneStore.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerData.Instance.nMoney >=1000)
        {
            Lv2Bigeye.SetActive(true);
            Lv2Misokatu.SetActive(true);
            Lv2EneStore.SetActive(true);
        }

        if (PlayerData.Instance.nScore == 1500)
        {

        }



    }
}
