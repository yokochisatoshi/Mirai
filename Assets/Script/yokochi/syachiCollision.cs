using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syachiCollision : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Human")
        {
            GameObject obj = null;
            human humanCs = other.gameObject.GetComponent<human>();
            if (humanCs.GetState() == (int)human.human_state.brainwashing)
            {
                GameObject[] StoreObjects = GameObject.FindGameObjectsWithTag("Store");
                for (int i = 0; i < StoreObjects.Length; i++)
                { // humanObjectsの要素分ループ
                    Store StoreScript = StoreObjects[i].GetComponent<Store>();              // humanスクリプト取得
                    if (StoreScript.food == humanCs.GetFavoriteFood())
                    {
                        obj = StoreObjects[i].gameObject;
                    }
                }

                humanCs.SetTargetAllyStore(obj);
                humanCs.SetState(human.human_state.allyBrainwashing);
                //other.transform.eulerAngles = new Vector3(0, 90, 0);
                // 洗脳状態移行時に入店可能フラグが変更ないなら特になし　あるなら入店フラグも変更

                // 好物のテクスチャ変更
                GameObject favoriteObj = other.gameObject.transform.Find("favorite").gameObject;
                favorite favoriteCs = favoriteObj.GetComponent<favorite>();
                favoriteCs.SetFavoriteTex();
            }
        }
    }
}
