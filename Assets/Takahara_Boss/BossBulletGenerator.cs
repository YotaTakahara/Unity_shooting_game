using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletGenerator : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] float radius;
    [SerializeField] float[] xRange=new float[2];
    [SerializeField] float[] yRange=new float[2];
    [SerializeField] float zRange;
    [SerializeField] private GameObject bull;
    [SerializeField] int bullNum;
    [SerializeField] RigidTakahara rb;


    public float span = 5.0f;
    public float power = 2000;
    float tmpSpan = 0;
    public Vector3 center;
    public Vector3 zurashi;


    void Start()
    {
        //rb = GetComponent<RigidTakahara>();
        boss = GameObject.Find("Boss");
        center =  boss.transform.position;
        bull =(GameObject) Resources.Load("EnemyBullet");

    }

    // Update is called once per frame
    void Update()
    {
        center = boss.transform.position;
        tmpSpan += Time.deltaTime;
        if(span<tmpSpan){
            tmpSpan = 0;
            Shoot();
        }



    }
    public void Shoot(){
        float x = Random.Range(xRange[0], xRange[1]);
        float y = Random.Range(yRange[0], yRange[1]);
        Vector3 where = new Vector3(x, y, zRange);
      //  Instantiate(bull, where, Quaternion.identity);
       Instantiate(bull, center+zurashi, Quaternion.identity);
       Vector3 direction = where - (center + zurashi);
        rb = bull.GetComponent<RigidTakahara>();
        Debug.Log("direction:" + direction.normalized);
        rb.AddForce(direction.normalized * power);
        Debug.Log("hurufhruhfurhfur");
    }
     public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(center+zurashi, radius);

    }
}
