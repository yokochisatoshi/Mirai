using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
<<<<<<< Updated upstream

    public int nMoney = 777;  // �����̂���
    public int nScore = 0;  // ������Score
    public int nTime = 0;    //���ԊǗ�  ���v�Ƃ��\�����鎞�p
    //�X�e�[�W�Ǘ��p   �X�e�[�W�����W�x�̂���
    public int nCurrentStage = 0;  
    public int nMaxStage = 3;
=======
    public int money = 777;  // �����̂���
>>>>>>> Stashed changes

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
        nTime++;
    }


    // �����𑝂₷���\�b�h
    public void AddMoney(int amount)
    {
        nMoney += amount;
       
    }

    public void AddScore(int amount)
    {
        nScore += amount;
    }
}
