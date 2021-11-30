using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float abs;
    GameObject airPlane;
    private Vector3 latestPos;
    public float num;
    public GameObject attackList;
    public List list;
    public List<GameObject> enemyList;

    public float span = 0.5f;

    //private float delta = 0;
    public float range;

    //銃弾役割切り替え成功
    //動作確認済み
    public int attackOrWall;


    void Start()
    {
         latestPos = transform.position;
        attackList = GameObject.Find("attackList");
        list = attackList.GetComponent<List>();
        enemyList = list.attack;
    }

    void Update()
    {
        Vector3 diff = transform.position - latestPos;
        if (diff.magnitude > range)
        {
            BulletDelete();
        }
    }
      void  BulletDelete(){
        Destroy(gameObject);
//        Debug.Log("delete");

    }
}