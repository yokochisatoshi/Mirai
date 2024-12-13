using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban01 : MonoBehaviour
{
    int nCounter = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Human")
        {
            nCounter--;
            if(nCounter <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
