using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syachihoko : MonoBehaviour
{
    public float destroyCount = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, destroyCount);
    }
}
