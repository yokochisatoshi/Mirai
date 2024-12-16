using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;


public class Kanban02 : MonoBehaviour
{

    int nCounter = 2;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
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
            collider.gameObject.GetComponent<human>().HitLv3();


        }
    }


}
