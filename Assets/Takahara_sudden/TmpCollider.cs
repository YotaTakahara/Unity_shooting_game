using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        GameObject tmp = GameObject.FindGameObjectWithTag("Monster");
        ColliderCube tmpCo = tmp.GetComponent<ColliderCube>();
        tmpCo.CheckCube(this.GetComponent<ISphere>());
        //Debug.Log("ここまでできた");


    }
}
