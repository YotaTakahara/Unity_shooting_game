using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : bulletController
{
    
    GameObject player;
    private Vector3 latestPos;
    public float num;
   

   

    //銃弾役割切り替え成功
    //動作確認済み
    public int attackOrWall;
    public int attackPoint = 1;


    // void Start()
    // {
    //     latestPos = transform.position;
    //     attackList = GameObject.Find("AttackList");
    //     list = attackList.GetComponent<List>();
    //     enemyList = list.attack;
    // }

    // void Update()
    // {
    //     Vector3 diff = transform.position - latestPos;
    //     if (diff.magnitude > range)
    //     {
    //         BulletDelete();
    //     }
    // }
    // void BulletDelete()
    // {
    //     Destroy(gameObject);
    //     //        Debug.Log("delete");

    // }
}
