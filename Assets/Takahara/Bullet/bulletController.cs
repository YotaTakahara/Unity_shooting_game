using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
   
   
    private Vector3 latestPos;
   

    public float span = 0.5f;

    //private float delta = 0;
    public float range;
    public GameObject attackList;
    public List list;
    public List<GameObject> enemyList;



    //銃弾役割切り替え成功
    //動作確認済み

    void Awake(){
        latestPos = transform.position;
        attackList = GameObject.Find("AttackList");
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
    void BulletDelete()
    {
        Destroy(gameObject);
        //        Debug.Log("delete");

    }
}