using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    private float LeftLim = -20f;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (transform.position.x < LeftLim)
        {
            Destroy(gameObject);
        }
    }
}
