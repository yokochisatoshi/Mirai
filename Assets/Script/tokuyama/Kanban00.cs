using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kanban00 : MonoBehaviour
{
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
        if(collider.gameObject.tag=="Human")
        {
            if (collider.gameObject.GetComponent<human>().GetState() == (int)human.human_state.normal)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
