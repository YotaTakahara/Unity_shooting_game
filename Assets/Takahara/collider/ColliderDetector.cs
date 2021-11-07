using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // [SerializeField] private GameObject _sphereObj;
    //[SerializeField] private GameObject[] attack;
    [SerializeField] public ColliderSphere check;
    [SerializeField] private GameObject air;
    [SerializeField] private GameObject attackList;
    [SerializeField] private List<GameObject> attack;
    [SerializeField] private air airScript;
    [SerializeField] private GameObject boss;
    [SerializeField] private BossZarigani zariScript;


    private ISphere _sphere;
    private bool _didCollide;
    public GameObject fire;
    

    private void Awake()
    {
        air = GameObject.Find("AirPlane");
        //attackColliderRoot = GameObject.Find("Monsters");
        //attack = GameObject.FindGameObjectsWithTag("Monster");
        boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            zariScript = boss.GetComponent<BossZarigani>();
        }

        _sphere = GetComponent<ISphere>();

        attackList = GameObject.Find("attackList");
        attack = attackList.GetComponent<List>().attack;
        airScript = air.GetComponent<air>();

        //  _colliders = attackColliderRoot.GetComponentsInChildren<ICollider>();
        //   _colliders = attackColliderRoot.GetComponentsInChildren<ICollider>();
        // Debug.Log("targetが取得できたか" + attack.Length);
        // Debug.Log("_sphere"+_sphere);
    }


    private void Update()
    {
        _didCollide = false;
        if (_sphere != null && attack != null)
        {
            // Debug.Log("ここまでは順調です");
            for (int i = 0; i < attack.Count; i++)
            {
                if (attack[i] != null&& attack[i].gameObject.tag!="enemyBullet")
                {
                    if(attack[i].tag=="Boss"){
                        ColliderSphere[] shin = attack[i].GetComponentsInChildren<ColliderSphere>();
                        for (int j = 0; j < shin.Length; j++)
                        {
                            _didCollide = shin[j].CheckSphere(_sphere);
                            
                            if (_didCollide)
                            {
                                zariScript.HP -= 1;
                               // Instantiate(fire, transform.position, Quaternion.identity);
                                Destroy(this.gameObject);



                            }

                        }




                    }
                    else
                    {

                        // _didCollide |= _colliders[i].CheckSphere(_sphere);

                        if (attack[i].GetComponent<ColliderSphere>() != null)
                        {
                            Debug.Log("ここが呼び出されいません");
                            ColliderSphere shin = attack[i].GetComponent<ColliderSphere>();
                            _didCollide = shin.CheckSphere(_sphere);
                            
                            if (_didCollide)
                            {
                                Instantiate(fire, transform.position, Quaternion.identity);
                                // int index = attack.IndexOf(attack[i]);
                                // attack.RemoveAt(index);
                                Destroy(attack[i]);
                                
                                airScript.point += 1;

                                
                            }
                        }
                        else
                        {
                            ColliderSphere[] shin = attack[i].GetComponentsInChildren<ColliderSphere>();
                            for (int j = 0; j < shin.Length; j++)
                            {
                                _didCollide = shin[j].CheckSphere(_sphere);
                                Debug.Log("原因はここです");

                                if (_didCollide)
                                {
                                    Instantiate(fire, transform.position, Quaternion.identity);
                                    // int index = attack.IndexOf(attack[i]);
                                    // attack.RemoveAt(index);
                                    Destroy(attack[i]);
                                    
                                    airScript.point += 1;

                                    //Debug.Log("無事衝突判定ができました");
                                }

                            }


                        }
                    }


                }
            }
        }
    }
}