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
    // [SerializeField] private air air;
    public GameObject fire;

    public void Start()
    {
        fire = (GameObject)Resources.Load("tryFire");
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
        // air = air.GetComponent<air>();
        //fire = GameObject.FindGameObjectWithTag("Fire");
        Initialize();
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
            //         air.Accident(attack[i]);
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


           

             if (attack[i] != null && attack[i].gameObject.tag == "enemyBullet")
            {
                if (attack[i].GetComponent<ColliderSphere>() != null)
                {
                       ColliderSphere shin = attack[i].GetComponent<ColliderSphere>();
                    _didCollideDamage = shin.CheckCapsuleCollision(transform.position, localPoint, maxLen, maxSeLen);


                    if (0<_didCollideDamage)
                    {
                        air.life -= _didCollideDamage;
                        StartCoroutine(LifeDisplay());



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

    IEnumerator LifeDisplay(){
        damageOccur.text = "銃弾Hit!!!";
        damageOccur.fontSize = 64;
        damageOccur.color = Color.yellow;
        yield return new WaitForSeconds(3.0f);
        damageOccur.text = "";
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