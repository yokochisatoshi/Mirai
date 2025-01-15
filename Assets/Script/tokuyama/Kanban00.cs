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
        // プレイヤーの状態による判定処理追加:横地
        if ((int)human.human_state.allyBrainwashing == collider.gameObject.GetComponent<human>().GetState() || (int)human.human_state.brainwashing == collider.gameObject.GetComponent<human>().GetState())
        {
            Destroy(this.gameObject);
        }
        else if (collider.gameObject.tag=="Human" && (int)human.human_state.Destroy != collider.gameObject.GetComponent<human>().GetState())
        {
            Destroy(this.gameObject);
        }
    }
}
