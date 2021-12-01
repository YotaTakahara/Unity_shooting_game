using System.Collections.Generic;
using UnityEngine;
using Ai;

public class ColliderDetectorForBullet : ColliderDetector
{

    [SerializeField] private bulletController bullController;
    [SerializeField] private int whichBull = 0;




    private ISphere _sphere;
    //private bool _didCollide;
    public GameObject fire;

    // GameObject cube;


    private void Start()
    {
        // air = GameObject.Find("AirPlane");
        // //attackColliderRoot = GameObject.Find("Monsters");
        // //attack = GameObject.FindGameObjectsWithTag("Monster");
        // boss = GameObject.FindGameObjectWithTag("Boss");
        // if (boss != null)
        // {
        //     zariScript = boss.GetComponent<BossZarigani>();
        // }

        _sphere = GetComponent<ISphere>();
        Initialize();

        bullController = GetComponent<bulletController>();
        whichBull = bullController.attackOrWall;

    }


    private void Update()
    {
        _didCollide = false;
        SphereDetection();
        if (whichBull == 1)
        {
            SphereDetection();
        }
        else if (whichBull == 2)
        {
            CubeDetection();

        }





    }

    //動作確認済み
    public void CubeDetection()
    {

        if (_sphere != null && obstacle != null)
        {

            for (int i = 0; i < obstacle.Count; i++)
            {
                if (obstacle[i] != null)
                {
                    ColliderCube cubeScript;
                    cubeScript = obstacle[i].GetComponent<ColliderCube>();
                    _didCollide = cubeScript.CheckCube(_sphere);

                    if (_didCollide)
                    {
                        Instantiate(fire, transform.position, Quaternion.identity);
                        // int index = attack.IndexOf(attack[i]);
                        // attack.RemoveAt(index);
                        Destroy(obstacle[i]);
                        Destroy(this.gameObject);

                        Debug.Log("dekitaaaaaa");

                        //  air.point += 1;
                        //pointAdder.PointCalcChange(1);


                    }
                }
            }
        }





    }



    public void SphereDetection()
    {
        if (_sphere != null && attack != null)
        {

            for (int i = 0; i < attack.Count; i++)
            {
                if (attack[i] != null && attack[i].gameObject.tag != "enemyBullet")
                {
                    if (attack[i].tag == "Boss")
                    {
                        ColliderSphere[] shin = attack[i].GetComponents<ColliderSphere>();
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
                            //Debug.Log("ここが呼び出されいません");
                            ColliderSphere shin = attack[i].GetComponent<ColliderSphere>();
                            _didCollide = shin.CheckSphere(_sphere);

                            if (_didCollide)
                            {
                                if (attack[i].gameObject.tag == "MonsterHP")
                                {
                                    attack[i].GetComponent<Enemy>().TakeDamage();
                                    Destroy(this.gameObject);


                                }
                                else
                                {
                                    if (attack[i] != null)
                                    {
                                        scoreController.RatioChange(attack[i]);

                                    }


                                    Instantiate(fire, transform.position, Quaternion.identity);


                                    Destroy(attack[i]);
                                    Destroy(this.gameObject);
                                    air.point += 1;
                                    pointAdder.PointCalcChange(1);
                                }


                            }
                        }
                        else
                        {
                            ColliderSphere[] shin = attack[i].GetComponentsInChildren<ColliderSphere>();
                            for (int j = 0; j < shin.Length; j++)
                            {
                                _didCollide = shin[j].CheckSphere(_sphere);
                                if (_didCollide)
                                {
                                    if (attack[i].gameObject.tag == "MonsterHP")
                                    {
                                        attack[i].GetComponent<Enemy>().TakeDamage();
                                        Destroy(this.gameObject);



                                    }
                                    // else
                                    // {
                                    //     Instantiate(fire, transform.position, Quaternion.identity);
                                    //     // int index = attack.IndexOf(attack[i]);
                                    //     // attack.RemoveAt(index);
                                    //     //

                                    //     // scoreController.RatioChange(attack[i]);
                                    //     Destroy(attack[i]);
                                    //     Destroy(this.gameObject);


                                    //     air.point += 1;
                                    //     pointAdder.PointCalcChange(1);

                                    //     Debug.Log("無事衝突判定ができました");
                                    // }
                                }

                            }


                        }
                    }


                }
            }
        }


    }
}