using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck : MonoBehaviour
{
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //   Debug.Log("shinneeee");

    }
    void  OnTriggerEnter2D(Collider2D other) {
        Debug.Log("衝突判定できました");
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("衝突判定できました");
    }
}
