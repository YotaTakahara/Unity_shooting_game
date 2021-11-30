using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Capsule;
using Ai;

public class ColliderDetectorForPlayer : ColliderDetector
{
    private float maxLen;
    private float maxSeLen;
    private int axis;
    private Vector3 localPoint;
    // [SerializeField] private GameObject attackList;
    // [SerializeField] private List<GameObject> attack;
    // [SerializeField] private bool _didCollide;
    [SerializeField] private MaxTry capsule;

    // [SerializeField] private GameObject air;
    // [SerializeField] private air airScript;
    public GameObject fire;

   public  void Awake()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        float[] number = { x, y, z };
        capsule = new MaxTry(number);
        axis = capsule.maxIndex;
        maxLen = capsule.maxLen;
        maxSeLen = capsule.maxSeLen;

        Debug.Log("maxLen " + maxLen);
        Debug.Log("axis " + axis);
        Debug.Log("maxSeLen " + maxSeLen);

        if (axis == 0)
        {
            localPoint = new Vector3(1, 0, 0);
        }
        else if (axis == 1)
        {
            localPoint = new Vector3(0, 1, 0);
        }
        else
        {
            localPoint = new Vector3(0, 0, 1);
        }

        //   fire = GameObject.FindGameObjectWithTag("Fire");
        // attackList = GameObject.Find("attackList");
        // attack = attackList.GetComponent<List>().attack;
        // air = GameObject.Find("air");
        // airScript = air.GetComponent<air>();
        //fire = GameObject.FindGameObjectWithTag("Fire");
    }

    void Update()
    {
       //s Debug.Log("huuuhu");
        _didCollide = false;
        SphereDetection();
        for (int i = 0; i < attack.Count; i++)
        {
            // if (attack[i] != null)
            // {
            //    // Debug.Log("_didCollide"+_didCollide);
            //     Vector3 diffPosition = attack[i].transform.position - transform.position;
            //     Vector3 relativePosition = transform.InverseTransformDirection(diffPosition);
            //     ColliderCapsule collTmp = new ColliderCapsule();
            //     _didCollide =collTmp.CheckCapsuleCollision(attack[i], relativePosition,localPoint,maxLen,maxSeLen);
            //     //   Debug.Log("_didCollide" + _didCollide);


            //     if (_didCollide)
            //     {
            //         airScript.Accident(attack[i]);
            //         Debug.Log("ookashii");
            //         //  Instantiate(fire, transform.position, Quaternion.identity);
                  
            //             Instantiate(fire, attack[i].transform.position, Quaternion.identity);
                    

            //         Destroy(attack[i]);
            //         // attack.RemoveAt(i);
            //         Debug.Log(attack[i]);
            //     }
            // }
        }
    }



    public void SphereDetection()
    {
       

            for (int i = 0; i < attack.Count; i++)
            {


                if (attack[i] != null && attack[i].gameObject.tag != "enemyBullet")
                {
                    
                    if (attack[i].tag == "Boss")
                    {
                        // ColliderSphere[] shin = attack[i].GetComponents<ColliderSphere>();
                        // for (int j = 0; j < shin.Length; j++)
                        // {
                        //      _didCollide = shin[j].CheckCapsuleCollision(transform.position,localPoint,maxLen,maxSeLen);

                        //     if (_didCollide)
                        //     {
                        //         zariScript.HP -= 1;
                        //         // Instantiate(fire, transform.position, Quaternion.identity);
                        //         Destroy(this.gameObject);




                        //     }

                        // }

                     }
                    else
                    {

                        // _didCollide |= _colliders[i].CheckSphere(_sphere);

                        if (attack[i].GetComponent<ColliderSphere>() != null)
                        {
                            //Debug.Log("ここが呼び出されいません");
                            ColliderSphere shin = attack[i].GetComponent<ColliderSphere>();
                        // _didCollide = shin.CheckSphere(_sphere);
                        _didCollide = shin.CheckCapsuleCollision(transform.position, localPoint, maxLen, maxSeLen);


                        if (_didCollide)
                            {
                                if (attack[i].gameObject.tag == "MonsterHP")
                                {
                                    attack[i].GetComponent<Enemy>().TakeDamage();
                                    Destroy(this.gameObject);


                                }
                                else
                                {


                                    Instantiate(fire, transform.position, Quaternion.identity);
                                    // int index = attack.IndexOf(attack[i]);
                                    // attack.RemoveAt(index);
                                    Destroy(attack[i]);
                                    Destroy(this.gameObject);


                                    airScript.point += 1;
                                }


                            }
                        }
                        else
                        {
                            ColliderSphere[] shin = attack[i].GetComponentsInChildren<ColliderSphere>();
                            for (int j = 0; j < shin.Length; j++)
                            {
                            //_didCollide = shin[j].CheckSphere(_sphere);
                            _didCollide = shin[j].CheckCapsuleCollision(transform.position, localPoint, maxLen, maxSeLen);


                            //Debug.Log("原因はここです");

                            if (_didCollide)
                                {
                                    if (attack[i].gameObject.tag == "MonsterHP")
                                    {
                                        attack[i].GetComponent<Enemy>().TakeDamage();
                                        Destroy(this.gameObject);



                                    }
                                    else
                                    {
                                        Instantiate(fire, transform.position, Quaternion.identity);
                                    // int index = attack.IndexOf(attack[i]);
                                    // attack.RemoveAt(index);
                                    Debug.Log("attack[i]:"+attack[i]);
                                    Destroy(attack[i]);
                                        Destroy(this.gameObject);
                                        


                                        airScript.point += 1;

                                        //Debug.Log("無事衝突判定ができました");
                                    }
                                }

                            }


                        }
                    }


                }

                else if(attack[i] != null && attack[i].gameObject.tag == "enemyBullet"){
                if (attack[i].GetComponent<ColliderSphere>() != null)
                {
//                    Debug.Log("ここが呼び出されいません");
                    ColliderSphere shin = attack[i].GetComponent<ColliderSphere>();
                    // _didCollide = shin.CheckSphere(_sphere);
                    _didCollide = shin.CheckCapsuleCollision(transform.position, localPoint, maxLen, maxSeLen);


                    if (_didCollide)
                    {
                                    


                            Instantiate(fire, transform.position, Quaternion.identity);
                        // int index = attack.IndexOf(attack[i]);
                        // attack.RemoveAt(index);
                        attack.Remove(attack[i]);
                        
                        Destroy(attack[i]);
                        // Destroy(this.gameObject);


                        Debug.Log("銃弾があたりました");



                    }
                }
                }
            
        }


    }
}




public class MaxTry
{
    //  public  float[] x;
    public int maxIndex;
    public float maxLen;
    public float maxSeLen;

    public MaxTry(float[] x)
    {
        int tmpIndex = 0;
        float tmpLen = x[0];
        float tmpSeLen = 0;
        for (int i = 0; i < x.Length; i++)
        {
            if (tmpLen < x[i])
            {
                tmpIndex = i;
                tmpLen = x[i];
            }
        }

        for (int i = 0; i < x.Length; i++)
        {
            if (i != tmpIndex && tmpSeLen < x[i])
            {
                tmpSeLen = x[i];
            }
        }

        this.maxIndex = tmpIndex;
        this.maxLen = tmpLen;
        this.maxSeLen = tmpSeLen;
    }
}