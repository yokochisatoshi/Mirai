using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class Kanban02 : MonoBehaviour
{

    int nCounter = 1;

    private Store.food_type sidefood;
    private bool bHit = false;
    
    // Start is called before the first frame update
    void Start()
    {
        LayerMask layerMask = 1 << LayerMask.NameToLayer("MyStore");
        RaycastHit hitOb;
        Vector3 vector3= Vector3.zero;

        if (this.gameObject.tag=="leftMarker")
        {
            vector3 = new Vector3(0.0f, 0.0f, 1.0f);
        }
        else if(this.gameObject.tag == "rightMarker")
        {
            vector3 = new Vector3(0.0f, 0.0f, -1.0f);
        }

        



        if(Physics.Raycast(this.transform.position, vector3, out hitOb, 100.0f, layerMask))
        {
            if(hitOb.collider.gameObject.tag == "Store")
            {
                sidefood = hitOb.collider.gameObject.GetComponent<Store>().food;
                bHit = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Human")
        {
            nCounter--;
            if (nCounter <= 0)
            {
                Destroy(this.gameObject);
            }
            //D‚Ý‚ÌH‚×•¨‚ð•ÏX‚·‚éˆ—
            if(bHit)
            {
                collider.gameObject.GetComponent<human>().HitLv3(sidefood);
            }
        }
    }
}
