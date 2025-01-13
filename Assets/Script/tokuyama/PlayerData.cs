using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    public int nMoney = 777;  // �����̂���
    public int nScore = 0;  // ������Score
    public float nTime = 0;    //���ԊǗ�  ���v�Ƃ��\�����鎞�p
    //�X�e�[�W�Ǘ��p   �X�e�[�W�����W�x�̂���
    public int nCurrentStage = 0;  
    public int nMaxStage = 3;

    //�����ɂ��ĂƂ�����ꂽ����(�L������)�̂��߂ɗp�ӂ������
    //�����Ȃ�̂ł�������ŕ�����
    public int nSumMoney = 0;
    public float nCountFade = 0;    //�����x   
    private float nFadeSpeed = 0.006f;
    public bool bAppear=false;

    //�Ƃ肠�����Ő��E��STOP�n�̂��
    public bool bShowResult = false;
    public bool bNextLevel = false;
    public bool bUseEneULT = false;
    public bool bUseMyULT = false;

    void Awake()
    {
        // �V���O���g��
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        nTime+=0.1f;


        if (bAppear)
        {
            nCountFade-=nFadeSpeed;

            if (nCountFade <= 0)
            {
                nMoney += nSumMoney;
                nSumMoney = 0;
                bAppear = false;
                nCountFade = 0; //����񂯂ǈꉞ
            }
        }

       //Score�ɉ����ăX�e�[�W���x�����ω����鏈��

        if(nCurrentStage == 0 && nScore>=300) 
        {
            nCurrentStage = 1;
            bNextLevel = true;
        }

        if (nCurrentStage == 1 && nScore >= 600)
        {
            nCurrentStage = 2;
            bNextLevel = true;
        }
        //���Ԃ�����Result�̕\��
        if(nTime >= 180) 
        {
            bShowResult = true;
        }
    }


    // �����𑝂₷���\�b�h
    public void AddMoney(int amount)
    {
        nSumMoney += amount;
        bAppear = true;
        nCountFade = 1;   //�����x   
    }

    public void AddScore(int amount)
    {
        nScore += amount;
    }

    public void Reset()
    {
        nMoney = 777;  // �����̂���
        nScore = 0;  // ������Score
        nTime = 0;    //���ԊǗ�  ���v�Ƃ��\�����鎞�p
        nCurrentStage = 0;
        nMaxStage = 3;
        nSumMoney = 0;
        nCountFade = 0;    //�����x   
        nFadeSpeed = 0.006f;
        bAppear = false;
        bShowResult = false;
        bNextLevel = false;
        bUseEneULT = false;
        bUseMyULT = false;
    }
}
