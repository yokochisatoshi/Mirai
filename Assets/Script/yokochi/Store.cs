using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public enum food_type
    {
        misokatu,
        uirou,
        BigEye,
    }

    public food_type food;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public food_type GetFoodType()
    {
        return food;
    }
}
