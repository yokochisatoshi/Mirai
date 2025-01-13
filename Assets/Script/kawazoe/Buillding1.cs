using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Buillding1 : MonoBehaviour
{
    public GameObject Hitsumabushi;
    public GameObject Tebasaki;
    public GameObject Raival1;

    void Start()
    {

    }

    void Update()
    {
        // score‚ªˆê’è‚É’B‚µ‚½ê‡
        if (PlayerData.Instance.nScore >= 1000)
        {
            Hitsumabushi.SetActive(true);
            Tebasaki.SetActive(true);
            Raival1.SetActive(true);

            Debug.Log("Œš’z‚µ‚Ü‚·I");
        }

    }
}