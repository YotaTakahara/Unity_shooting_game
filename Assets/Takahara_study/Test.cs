using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] RigidTakahara shin;


    void Start(){
        shin = GetComponent<RigidTakahara>();

    }
    void Update()
    {

        var rb = GetComponent<Rigidbody>();
        Vector3 omega = new Vector3(0f, 1f, 0f);
        Vector3 Id = rb.inertiaTensor;
        Quaternion Ir = rb.inertiaTensorRotation;
        Quaternion IrI = Quaternion.Inverse(Ir);
        //T=I*omega;
        //rotationはQuaternionじゃないと適用できないみたい
        Quaternion R = transform.rotation;
        Quaternion RI = Quaternion.Inverse(R);

        Vector3 torque =R*Ir* Vector3.Scale(Id, IrI *RI* omega);


        shin.AddTorque(torque);


        // if(Input.GetMouseButton(0)){
        //     var rb = GetComponent<Rigidbody>();
        //     Vector3 omega = new Vector3(0f, 1f, 0f);
        //     Vector3 Id = rb.inertiaTensor;
        //     Quaternion Ir = rb.inertiaTensorRotation;
        //     Quaternion IrI = Quaternion.Inverse(Ir);
        //     //T=I*omega;
        //     //rotationはQuaternionじゃないと適用できないみたい
        //     Quaternion R = transform.rotation;
        //     Quaternion RI = Quaternion.Inverse(R);

        //     Vector3 torque =R*Ir* Vector3.Scale(Id, IrI *RI* omega);



        //     rb.AddTorque(torque, ForceMode.Impulse);
        // }
        
    }
}
