using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Capsule;

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
        for (int i = 0; i < attack.Count; i++)
        {
            if (attack[i] != null)
            {
                Vector3 diffPosition = attack[i].transform.position - transform.position;
                Vector3 relativePosition = transform.InverseTransformDirection(diffPosition);

                ColliderCapsule collTmp = new ColliderCapsule();
                _didCollide =collTmp.CheckCapsuleCollision(attack[i], relativePosition,localPoint,maxLen,maxSeLen);
                //   Debug.Log("_didCollide" + _didCollide);


                if (_didCollide)
                {
                    airScript.Accident(attack[i]);
                    Debug.Log("ookashii");
                    //  Instantiate(fire, transform.position, Quaternion.identity);
                    if (attack[i].gameObject.tag == "Monster")
                    {
                        Instantiate(fire, attack[i].transform.position, Quaternion.identity);
                    }

                    Destroy(attack[i]);
                    // attack.RemoveAt(i);
                    Debug.Log(attack[i]);
                }
            }
        }
    }

    public void SphereDetection(){

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