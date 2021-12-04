using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderDetector : ControllerBase
{
    // Start is called before the first frame update
    // public GameObject air;
    // public GameObject attackList;
    public Text damageOccur;
    public List<GameObject> attack;
    public List<GameObject> obstacle;
    //public air airScript;
    public GameObject boss;
    public BossZarigani zariScript;
    public bool _didCollide;
    public int _didCollideDamage=0;
    public void Initialize()
    {
        GameObject textTmp = GameObject.Find("DamageOccur");
        damageOccur = textTmp.GetComponent<Text>();
        // air = GameObject.Find("AirPlane");
        //attackColliderRoot = GameObject.Find("Monsters");
        //attack = GameObject.FindGameObjectsWithTag("Monster");
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            zariScript = boss.GetComponent<BossZarigani>();
        }

        // _sphere = GetComponent<ISphere>();

        // attackList = GameObject.Find("AttackList");
        attack = list.attack;
        //henkou
        obstacle = list.obstacle;

        // airScript = air.GetComponent<air>();

    }


}
