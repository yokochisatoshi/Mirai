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
            human humanCs = other.gameObject.GetComponent<human>();
            if (humanCs.GetState() == (int)human.human_state.brainwashing)
            {
                humanCs.SetState((int)human.human_state.normal);
                other.transform.eulerAngles = new Vector3(0, 90, 0);
                // 洗脳状態移行時に入店可能フラグが変更ないなら特になし　あるなら入店フラグも変更

                // 好物のテクスチャ変更
                GameObject favoriteObj = other.gameObject.transform.Find("favorite").gameObject;
                favorite favoriteCs = favoriteObj.GetComponent<favorite>();
                favoriteCs.SetFavoriteTex();
            }
        }
    }
}
