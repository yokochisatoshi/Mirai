using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShop : MonoBehaviour
{
    public int cooltime = 100;      // �K�E�Z�̃N�[���^�C��
    public int count = 0;           // �N�[���^�C���̃J�E���^
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        count++;
        if (count > cooltime)
        { // cooltime�����Ԃ��o������
            count = 0;
            GameObject[] humanObjects = GameObject.FindGameObjectsWithTag("Human");     // ���݂���Human�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[
            for(int i = 0;i < humanObjects.Length; i++)
            { // humanObjects�̗v�f�����[�v
                human humanScript = humanObjects[i].GetComponent<human>();              // human�X�N���v�g�擾
                if (humanScript.GetState() == (int)human.human_state.normal)
                { // �擾����humanScript�̏�Ԃ�normal�Ȃ�
                    humanScript.SetTargetEnemyStore(this.gameObject);                   // �擾����human�X�N���v�g�̌������G�̓X�����̃I�u�W�F�N�g�ɂ���
                    humanScript.SetState(human.human_state.brainwashing);               // �擾����human�X�N���v�g�̏�Ԃ�brainwashing�ɏ�ԑJ��
                }
            }
        }
    }
}
