using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human : MonoBehaviour
{
    List<Material> childMr = new List<Material>();    // �S�Ă̎q�I�u�W�F�N�g�̃}�e���A���i�[���Ă��炢����

    public enum human_state // �l�̏��
    {
        normal,         // �m�[�}�����
        eat,            // �H�����
        brainwashing,   // ���](�G�K�E)
        Destroy,        // �ޓX
    }

    // �D���͏o�X���Ă���X�̒����烉���_���Őݒ肳���
    private Store.food_type favorite;

    public float speed;
    GameObject ManageData;
    PlayerData script;
    GameObject child;

    bool bCanStore = false;

    int state = (int)human_state.normal;        // �l�̏��(���ŏ�����normal)
    int eatCunt = 0;                            // �H�����ԃJ�E���^
    public int eatTime;                         // �H���ɂ����鎞��
    public int DestroyTime;                     // ���ł���܂ł̎���         

    MeshRenderer mr;          // �������p

    GameObject EnemyTarget;

    // Start is called before the first frame update
    void Start()
    {
        ManageData = GameObject.Find("ManageData");
        script = ManageData.GetComponent<PlayerData>();

        mr = GetComponent<MeshRenderer>();      // �������p(�}�e���A�����擾�H)

        // �o�����Ă���X�����ׂĎ擾
        GameObject[] StoreObjects = GameObject.FindGameObjectsWithTag("Store");     // ���݂���Store�^�O�������Ă���I�u�W�F�N�g��z��Ɋi�[

        // ���̂Ȃ����烉���_���ɐݒ�
        if (StoreObjects.Length != 0)
        {
            int num = Random.Range(0, StoreObjects.Length);
            Store storeCs = StoreObjects[num].GetComponent<Store>();
            favorite = storeCs.GetFoodType();
        }

        child = transform.Find("favorite").gameObject;

        GetAllChildMr();        // �S�Ă̎q�I�u�W�F�N�g�̃}�e���A�����擾���Ċi�[
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �ړ�����(���ʂɈړ�)
        Vector3 pos = transform.position;


        // �Ƃ肠����Y���W�����ȉ��Ȃ����
        if (this.transform.position.y < -2.0f)
        {
            Destroy(this.gameObject);
        }

        switch (state)
        {
            case (int)human_state.normal:
                // �ړ�����(���ʂɈړ�)
                pos += transform.forward * speed;
                transform.position = pos;
                break;
            case (int)human_state.eat:          // �H����
                eatCunt++;
                if (eatCunt > eatTime)
                { // ��莞�ԐH��������
                    //Debug.Log("unnti");
                    eatCunt = 0;
                    state = (int)human_state.Destroy;                               // �ޓX��ԂɑJ��
                    this.gameObject.transform.eulerAngles = new Vector3(0, 180, 0); // �v���C���[���o���Ɍ�����
                }
                break;
            case (int)human_state.Destroy:      // �ޓX���
                // �ړ�����(���ʂɈړ�)
                pos += transform.forward * speed;
                transform.position = pos;

                for (int i = 0; i < childMr.Count; i++)
                {
                    childMr[i].color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));
                }

                mr.material.color = mr.material.color - new Color32(0, 0, 0, (byte)(mr.material.color.a + 5));  // �����ɂ��Ă���
                Destroy(this.gameObject, DestroyTime);                                                           // ��莞�Ԍo������E��
                break;
            case (int)human_state.brainwashing: // ���]���
                this.transform.LookAt(EnemyTarget.transform);   // �ړI�̓X�̕���������
                // ���ʂɈړ�
                pos += transform.forward * speed;
                transform.position = pos;
                break;
        }
    }


    // �v���C���[���̓����蔻��
    void OnCollisionEnter(Collision collision)
    {
        if (state == (int)human_state.normal)
        {

            // ��
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
                // Debug.Log("hitfront");
            }

            if (other.gameObject.tag == "Store" && bCanStore == true)
            { // �X�ɓ���������
                state = (int)human_state.eat;       // �H����ԂɑJ��
                script.AddMoney(150);               // �������Z
            }
            else if (other.gameObject.tag == "EnemyStore" && bCanStore == true)
            { // �G�̓X����������
                state = (int)human_state.eat;       // �H����ԂɑJ��
            }
        }

        if (state == (int)human_state.brainwashing && other.gameObject.name == EnemyTarget.name)
        { // ���]��Ԃ��ړI�̓G�̓X�ɓ���������
            //Debug.Log("e store");
            state = (int)human_state.eat;       // �H����ԂɑJ��
        }
    }

    // ��ԑJ�ڊ֐�
    public void SetState(human_state _state)
    {
        state = (int)_state;
        if (_state == human_state.brainwashing) child.GetComponent<favorite>().SetBrainwashingTex();
    }

    // ��Ԏ擾�֐�
    public int GetState()
    {
        return state;
    }

    // �G�̌������X�Z�b�g�֐�
    public void SetTargetEnemyStore(GameObject _target)
    {
        EnemyTarget = _target;
    }

    public Store.food_type GetFavoriteFood()
    {
        return favorite;
    }

    // �q�}�e���A���擾�֐�
    public void GetAllChildMr()
    {
        List<GameObject> childbjects = new List<GameObject>();

        // �e�I�u�W�F�N�g��Transform���炷�ׂĂ̎q�I�u�W�F�N�g�i�q�̎q�̎q��...�j���擾
        GetChildren(this.gameObject, ref childbjects);

        for (int i = 0; i < childbjects.Count; i++)
        {
            // �q�I�u�W�F�N�g��Transform���擾
            Transform childTransform = childbjects[i].GetComponent<Transform>();

            if (childTransform != null)
            {
                // �q�I�u�W�F�N�g��Renderer���擾
                Renderer childRenderer = childTransform.GetComponent<Renderer>();

                if (childRenderer != null)
                {
                    // �q�I�u�W�F�N�g��Material���i�[
                    childMr.Add(childRenderer.material);
                }
            }
        }
    }

    //�q�v�f���擾���ă��X�g�ɒǉ�
    public void GetChildren(GameObject obj, ref List<GameObject> allChildren)
    {
        Transform children = obj.GetComponentInChildren<Transform>();
        //�q�v�f�����Ȃ���ΏI��
        if (children.childCount == 0)
        {
            return;
        }
        foreach (Transform ob in children)
        {
            allChildren.Add(ob.gameObject);
            GetChildren(ob.gameObject, ref allChildren);
        }
    }

}