using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Data;

public class ManageGUI : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;

    private bool bCanSet = false;
    private bool bHitGrand = false;
    private int nInterval = 5;
    private int nCntInterval = 0;
    //看板系のObjectまとめ

    public GameObject Kanban00_Left;
    public GameObject Kanban00_Right;
    //代入されるプレビューの入れ物
    private GameObject PreViewObject;
    private BoxCollider PreViewColider;
    private Color PreViewColor;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nCntInterval++;
        if (bCanSet)
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var raycastHitList = Physics.RaycastAll(ray);

            bHitGrand = false;
            //マウスから地形のPosを計算
            for (int i = 0; i < raycastHitList.Length; i++)
            {
                if (raycastHitList[i].collider.tag == "Grand")
                {
                    var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList[i].point);
                    var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                    currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
                    currentPosition.y = 0;
                    //マウスが地面上にあったかどうか
                    bHitGrand = true;
                    PreViewObject.transform.position = currentPosition;
                }
            }

            //設置が可能な状態で左クリックを押した if
            if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) && nCntInterval > nInterval)
            {
                if (bHitGrand == false)
                {
                    Destroy(PreViewObject);
                }
                else
                {
                    PreViewColider.enabled = true;
                    PreViewColor.a = 1.0f;
                    PreViewColor.r = 1.0f;
                    PreViewColor.g = 1.0f;
                    PreViewObject.GetComponent<Renderer>().material.color = PreViewColor;
                }
                nCntInterval = 0;
                bCanSet = false;
            }
            //設置前か後かで当たり判定と半透明のif

        }
    }
    public void ClickKanban00()
    {
        if (bCanSet == true) { return; }

        bCanSet = true;
        //プレビューたちに代入
        PreViewObject = Instantiate(Kanban00_Left, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
        PreViewColider=PreViewObject.GetComponent<BoxCollider>();
        PreViewColor=PreViewObject.GetComponent<Renderer>().material.color;

        //
        PreViewColider.enabled = false;
        PreViewColor.a = 0.5f;
        PreViewColor.r = 0.5f;
        PreViewColor.g = 0.5f;
        PreViewObject.GetComponent<Renderer>().material.color = PreViewColor;
    }

    public void ClickKanban01()
    {
        if (bCanSet == true) { return; }

        bCanSet = true;

        PreViewObject = Instantiate(Kanban00_Right, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
    }

}
