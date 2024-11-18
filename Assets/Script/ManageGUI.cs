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
    private int nInterval = 3;
    private int nCntInterval = 0;

    public GameObject Kanban00_Left;
    public GameObject Kanban00_Right;

    private GameObject PreViewObject;

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

            //設置が可能の状態 if
            if (Input.GetMouseButtonDown(0) && nCntInterval > nInterval)
            {
                Debug.Log("Click");
                nCntInterval = 0;
                bCanSet = false;

                if (bHitGrand == false)
                {
                   Destroy(PreViewObject);
                }
                else
                {

                }
            }
        }
    }


    public void LeftClickKanban00()
    {
        if (bCanSet) return;
        if (nCntInterval > nInterval)
        {
          
            nCntInterval = 0;
            bCanSet = true;

            PreViewObject= Instantiate(Kanban00_Left, new Vector3(-10,0,0), Quaternion.Euler(0, 0, 0));
        }
    }

    public void RightClickKanban00()
    {
        if (bCanSet) return;
        if (nCntInterval > nInterval)
        {
            nCntInterval = 0;
            bCanSet = true;

            PreViewObject = Instantiate(Kanban00_Right, new Vector3(-10, 0, 0), Quaternion.Euler(0, 0, 0));
        }
    }

}
