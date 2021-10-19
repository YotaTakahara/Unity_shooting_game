using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerayota : MonoBehaviour
{
    Rigidbody shin;
    public GameObject target;
    public float followSpeed;
    public Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        shin = GetComponent<Rigidbody>();
      //  diff = target.transform.position - transform.position;

    }

    // Update is called once per frame
    void Update()
    {
       Vector3 diff = target.transform.position - transform.position;
        shin.AddForce(diff);
    //     transform.position = Vector3.Lerp(transform.position, target.transform.position - diff,
    //         followSpeed * Time.deltaTime);
        Quaternion rot = Quaternion.LookRotation(diff);
        transform.rotation = rot;
        Quaternion r = rot * Quaternion.Inverse(transform.rotation);
        if(r.w<0){
            r.x = -r.x;
            r.y = -r.y;
            r.z = -r.z;
            r.w = -r.w;
            
        }
        shin.AddTorque(new Vector3(r.x, r.y, r.z));



    }
}
