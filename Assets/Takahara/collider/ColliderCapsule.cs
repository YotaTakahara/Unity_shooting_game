using System.Collections.Generic;
using UnityEngine;

public class ColliderCapsule : MonoBehaviour
{
    // [SerializeField] private GameObject[] enemy;
    // [SerializeField] private GameObject[] enemyBullet;
    // public  List<GameObject> attack;
    public GameObject fire;

    private float maxLen;
    private float maxSeLen;
    private int axis;
    private Vector3 localPoint;
    [SerializeField] private GameObject attackList;
    [SerializeField] private List<GameObject> enemyBox;
    [SerializeField] private bool _didCollide;
    [SerializeField] private MaxTry capsule;


    // Start is called before the first frame update
    void Start()
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;
        float[] number = {x, y, z};
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

        fire = GameObject.Find("fire");
        attackList = GameObject.Find("attackList");
        enemyBox = attackList.GetComponent<List>().attack;
    }

    // Update is called once per frame
    void Update()
    {
        _didCollide = false;
        for (int i = 0; i < enemyBox.Count; i++)
        {
            if (enemyBox[i] != null)
            {
                Vector3 diffPosition = enemyBox[i].transform.position - transform.position;
                Vector3 relativePosition = transform.InverseTransformDirection(diffPosition);


                _didCollide = CheckCapsuleCollision(enemyBox[i], relativePosition);
                //   Debug.Log("_didCollide" + _didCollide);


                if (_didCollide)
                {
                    Instantiate(fire, transform.position, Quaternion.identity);
                    enemyBox.RemoveAt(i);
                    Debug.Log(enemyBox[i]);
                    Destroy(enemyBox[i]);
                }
            }
        }
    }

    public bool CheckCapsuleCollision(GameObject ene, Vector3 localDiffPlace)
    {
        float naiseki = Vector3.Dot(localDiffPlace, localPoint);
        float absN = Mathf.Abs(naiseki);

        if (maxLen < absN)
        {
            return false;
        }
        else
        {
            if (maxLen - maxSeLen <= absN && absN <= maxLen)
            {
                Debug.Log("localMyPlace " + localDiffPlace);
                Debug.Log("localPoint " + localPoint);
                Debug.Log("naiseki " + naiseki);
                Vector3 circleCenter = (maxLen - maxSeLen) * localPoint * naiseki / (Mathf.Abs(naiseki));
                Vector3 circleDistance = circleCenter - localDiffPlace;
                Debug.Log("circleCenter " + circleCenter + " circleDistance " + circleDistance.magnitude +
                          " ene.transform.localScale.x " +
                          ene.transform.localScale.x);
                if (circleDistance.magnitude < ene.transform.localScale.x + maxSeLen)
                {
                    Debug.Log("円判定");
                    return true;
                }
            }

            if (absN < maxLen - maxSeLen)
            {
                Vector3 line = naiseki * localPoint;
                Vector3 lineDistance = line - localDiffPlace;
                Debug.Log("line " + line + " lineDistance " + lineDistance.magnitude + " ene.transform.localScale.x " +
                          ene.transform.localScale.x);

                if (lineDistance.magnitude < ene.transform.localScale.x + maxSeLen)
                {
                    Debug.Log("カプセル判定");
                    return true;
                }
            }
        }

        return false;
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