using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalHome : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected() 
    {
        foreach (Transform child in transform) {
            child.tag = gameObject.tag;
        }
    }
}
