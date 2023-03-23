using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    
    private float bound = -20;

    void Update()
    {
        
        if (transform.position.z < bound) {
        
            Destroy(gameObject);

        }

    }
}
