using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCube : MonoBehaviour, ICollider, ICube
{
    //壁判定簡易的に実装済み
    public Vector3 _center = Vector3.zero;
    public float k;
    public bool now = false;


    public Vector3 Center
    {
        get { return _center; }
    }
    // public float X
    // {
    //     get { return transform.localScale.x; }
    // }
    // public float Y
    // {
    //     get { return transform.localScale.y; }
    // }
    // public float Z
    // {
    //     get { return transform.localScale.z; }
    // }
    public float X
    {
        get { return transform.lossyScale.x; }
    }
    public float Y
    {
        get { return transform.lossyScale.y; }
    }
    public float Z
    {
        get { return transform.lossyScale.z; }
    }
    public Vector3 WorldCenter
    {
        get { return _center + transform.position; }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool CheckSphere(ISphere collider) { return false; }
    public bool CheckCube(ISphere collider)
    {

        float distance = Vector3.Magnitude(collider.WorldCenter - this.WorldCenter);


        distance = Vector3.Magnitude(new Vector3(collider.WorldCenter.x - this.WorldCenter.x, 0, collider.WorldCenter.z - this.WorldCenter.z));
        float distanceSideX = Mathf.Abs(WorldCenter.x - collider.WorldCenter.x);
        float distanceSideY = Mathf.Abs(WorldCenter.y - collider.WorldCenter.y);
        float distanceSideZ = Mathf.Abs(WorldCenter.z - collider.WorldCenter.z);
        if (distance <= collider.Radius + this.X / 2 && distanceSideZ < Z && distanceSideY < Y)
        {
            now = true;
            Debug.Log("当たり判定成功");

            return true;

        }
        else if (distance <= collider.Radius + this.Z / 2 && distanceSideX < X && distanceSideY < Y)
        {
            now = true;
            Debug.Log("当たり判定成功");

            return true;

        }

        else
        {
            return false;
        }
    }
    void OnDrawGizmos()
    {
        if (now == true)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;

        }

        //Gizmos.color = Color.green;
        Gizmos.DrawWireCube(WorldCenter, new Vector3(X, Y, Z));



    }
}
