using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
<<<<<<< Updated upstream
    public enum human_state // �l�̏��
    {
        normal,     // �m�[�}�����
        eat,        // �H�����
        Destroy,    // �ޓX
    }



    public float speed;
    GameObject ManageData;
    PlayerData script;
=======
>>>>>>> Stashed changes

    public enum human_state // �l�̏��
    {
        normal,     // �m�[�}�����
        eat,        // �H�����
        Destroy,    // �ޓX
    }

    public float speed;                         // �����X�s�[�h
    public PlayerData playerData;
    bool bCanStore = false;
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
    int state = (int)human_state.normal;        // �l�̏��(���ŏ�����normal)
    int eatCunt = 0;                            // �H�����ԃJ�E���^
    public int eatTime;                         // �H���ɂ����鎞��
    public int DestroyTime;                     // ���ł���܂ł̎���         

    MeshRenderer mr;          // �������p
<<<<<<< Updated upstream


    // Start is called before the first frame update
    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

=======
    // Start is called before the first frame update
    void Start()
    {
>>>>>>> Stashed changes
        mr = GetComponent<MeshRenderer>();      // �������p(�}�e���A�����擾�H)
    }

    // Update is called once per frame
    void FixedUpdate()
    {
<<<<<<< Updated upstream
        // �ړ�����(���ʂɈړ�)
        Vector3 pos = transform.position;
       

        // �Ƃ肠����Y���W�����ȉ��Ȃ����
        if(this.transform.position.y < -1.0f)
=======
        Vector3 pos = transform.position;       // �v���C���[�̍��W�擾

        // �Ƃ肠����Y���W�����ȉ��Ȃ����
        if (this.transform.position.y < 1.5)
>>>>>>> Stashed changes
        {
            Destroy(this.gameObject);
        }

<<<<<<< Updated upstream
=======
        // �v���C���[���
>>>>>>> Stashed changes
        switch (state)
        {
            case (int)human_state.normal:
                // �ړ�����(���ʂɈړ�)
                pos += transform.forward * speed;
                transform.position = pos;
                break;
            case (int)human_state.eat:          // �H����
<<<<<<< Updated upstream
                eatCunt++;
                if (eatCunt > eatTime)
                { // ��莞�ԐH��������
                    Debug.Log("unnti");
=======
                eatCunt++;                  
                if(eatCunt > eatTime)
                { // ��莞�ԐH��������
>>>>>>> Stashed changes
                    eatCunt = 0;
                    state = (int)human_state.Destroy;                               // �ޓX��ԂɑJ��
                    this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0); // �v���C���[���o���Ɍ�����
                }
                break;
            case (int)human_state.Destroy:      // �ޓX���
                // �ړ�����(���ʂɈړ�)
                pos += transform.forward * speed;
                transform.position = pos;

<<<<<<< Updated upstream
                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));  // �����ɂ��Ă���
                Destroy(this.gameObject, DestroyTime);                                                           // ��莞�Ԍo������E��
                break;
        }



=======
                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 1));  // �����ɂ��Ă���
                Destroy(this.gameObject,DestroyTime);                                                           // ��莞�Ԍo������E��
                break;
        }
>>>>>>> Stashed changes
    }




    // �v���C���[���̓����蔻��
    void OnCollisionEnter(Collision collision)
<<<<<<< Updated upstream
    {
        if (state == (int)human_state.normal)
        {

            // ��
=======
    { // �ʏ��ԂȂ�
        // ��
        if (state == (int)human_state.normal)
        {
>>>>>>> Stashed changes
            if (collision.gameObject.tag == "wall")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (state == (int)human_state.normal)
<<<<<<< Updated upstream
        {

            // �W���H
            if (other.gameObject.tag == "backMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "leftMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "rightMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "frontMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = true;
                Debug.Log("hitfront");
            }

            if (other.gameObject.tag == "Store" && bCanStore == true)
            {
                Debug.Log("store");
                // Destroy(this.gameObject);
                state = (int)human_state.eat;       // �H����ԂɑJ��
                script.AddMoney(150);

            }
        }
=======
        { // �ʏ��ԂȂ�
            // �W���H
            if (other.gameObject.tag == "backMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 270, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "leftMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "rightMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
                bCanStore = true;
            }
            if (other.gameObject.tag == "frontMarker")
            {
                this.gameObject.transform.eulerAngles = new Vector3(0, 90, 0);
                bCanStore = true;
                Debug.Log("hitfront");
            }
            // �X
            if (other.gameObject.tag == "Store" && bCanStore == true)
            {
                Debug.Log("store");
                state = (int)human_state.eat;       // �H����ԂɑJ��
                playerData.AddMoney(150);

            }
        } 
>>>>>>> Stashed changes
    }
}
