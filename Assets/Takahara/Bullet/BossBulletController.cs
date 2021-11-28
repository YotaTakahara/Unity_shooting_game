using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletController : bulletController
{
    // Start is called before the first frame update
    public GameObject targetUI;
    public Vector3 startPoint;

    void Update() {
        float distance = Vector3.Magnitude(transform.position - startPoint);
        float distance1 = Vector3.Magnitude(targetUI.transform.position - startPoint);
//        Debug.Log("targetUI:" + targetUI.transform.position);
        if(this.transform.position.z<-1.0f){
            EveryDelete();
        }



    }

    // Update is called once per frame
    public  void EveryDelete(){
        Destroy(targetUI.gameObject);
        Destroy(gameObject);
        Debug.Log("きえた!!!!");

    }
}
