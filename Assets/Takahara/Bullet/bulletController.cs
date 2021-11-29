using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float abs;
    GameObject airPlane;
    private Vector3 latestPos;
    public float num;
    [SerializeField] private GameObject attackList;
    [SerializeField] private List<GameObject> enemy;

    public float span = 0.5f;

    //private float delta = 0;
    public float range;

    //銃弾役割切り替え成功
    //動作確認済み
    public int attackOrWall;


    void Start()
    {
         latestPos = transform.position;
        // attackList = GameObject.Find("attackList");
        // enemy = attackList.GetComponent<List>().attack;
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
        Debug.Log("delete");

    }
}