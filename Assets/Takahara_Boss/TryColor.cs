using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class TryColor : MonoBehaviour
{
    //public static Color color { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnDrawGizmos() {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, this.transform.localScale.x/2);    
    }

   
}
