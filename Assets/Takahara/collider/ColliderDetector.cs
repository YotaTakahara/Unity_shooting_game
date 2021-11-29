using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject air;
    public GameObject attackList;
    public List<GameObject> attack;
    public List<GameObject> obstacle;
    public air airScript;
    public GameObject boss;
    public BossZarigani zariScript;
    public bool _didCollide;
    public void Start()
    {
        air = GameObject.Find("AirPlane");
        //attackColliderRoot = GameObject.Find("Monsters");
        //attack = GameObject.FindGameObjectsWithTag("Monster");
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            zariScript = boss.GetComponent<BossZarigani>();
        }

       // _sphere = GetComponent<ISphere>();

        attackList = GameObject.Find("attackList");
        attack = attackList.GetComponent<List>().attack;
        //henkou
        obstacle = attackList.GetComponent<List>().obstacle;

        airScript = air.GetComponent<air>();
        
    }

    
}
