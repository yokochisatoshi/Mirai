using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI moneyText2;

    private float text2R;
    private float text2G;
    private float text2B;

    private float Fade = 255;
  

    // Start is called before the first frame update
    void Start()
    {
        text2R = moneyText2.color.r;
        text2G = moneyText2.color.g;
        text2B = moneyText2.color.b;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        moneyText.text = "Money: " + PlayerData.Instance.nMoney;

        //消えてく方のテキストMoney
        moneyText2.text =   "+"    + PlayerData.Instance.nSumMoney;

        //Fade--;
        moneyText2.color = new Color(0.0f, 0.0f, 0.0f,PlayerData.Instance.nCountFade);
        //Debug.Log(moneyText2.color.a);
    }
}
