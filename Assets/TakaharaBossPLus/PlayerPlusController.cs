using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlusController : MonoBehaviour
{
  [SerializeField] private GameObject boss;
    [SerializeField] private CircleLine circleLine;
    [SerializeField] private float radius = 60f;
  [SerializeField] private float speed = 0.4f;
  [SerializeField] private Vector3 center = Vector3.zero;
  [SerializeField] private float rad = 0f;

  float x;
  float y;
  float z;
    Vector3 firstPos;
    int which = 0;
    bool rotateFlag = true;

    float error = 5f;
    void Start()
  {
    radius = Vector3.Magnitude(new Vector3(boss.transform.position.x - transform.position.x, 0, boss.transform.position.z - transform.position.z));
    boss = GameObject.Find("Boss");
        circleLine = boss.GetComponent<CircleLine>();
        firstPos = transform.position;

    }

  void FixedUpdate()
  {

    //Debug.Log("nanndeyanenn");
    if(Input.GetKey("up")){

      if(CheckVertical()==true&&which!=2)CircleRotation1(-1);
      if (CheckVertical1() == true&&which !=1) CircleRotation2(-1);
    }

        if (Input.GetKey("down"))
        {

            if (CheckVertical() == true&&which!=2) CircleRotation1(1);
            if (CheckVertical1() == true&&which!=1) CircleRotation2(1);
        }

        if (Input.GetKey("left")&&CheckHorizontal()==true) CircleRotation(-1);
    if (Input.GetKey("right")&&CheckHorizontal()==true) CircleRotation(1);
    WhereToLook();
      //  RotateHalf();
    }
  public void WhereToLook()
  {
    Vector3 diff = boss.transform.position - transform.position;
    Quaternion quaternion = Quaternion.LookRotation(diff);
    this.transform.rotation= quaternion;

  }
  public void RotateHalf(){
    if(Mathf.Abs(transform.position.x)<0.5f&&Mathf.Abs(transform.position.z)<0.5f&&rotateFlag==true){
            rotateFlag = false;
            Debug.Log("nannde");
            transform.Rotate(0, 90f, 0);
        }else{
            rotateFlag = true;
        }
  }
  public void CircleRotation(int check)
  {
    which = 0;
    rad += (check) * speed * 2 * Mathf.PI / 360;
    x = radius * Mathf.Cos(rad);
    z = radius * Mathf.Sin(rad);
    transform.position = new Vector3(x + center.x, firstPos.y, z + center.z);
  }
    public void CircleRotation1(int check)
    {
        which = 1;
        rad += (check) * speed * 2 * Mathf.PI / 360;
        z = radius * Mathf.Cos(rad);
        y = radius * Mathf.Sin(rad);
        transform.position = new Vector3(firstPos.x, y+center.y, z + center.z);
    }
    public void CircleRotation2(int check)
    {
        which = 2;
        rad += (check) * speed * 2 * Mathf.PI / 360;
        x = radius * Mathf.Cos(rad);
        y = radius * Mathf.Sin(rad);
        transform.position = new Vector3(x+center.x, y + center.y, firstPos.x);
    }
  public bool CheckHorizontal(){
    if(Mathf.Abs(transform.position.y-firstPos.y)<error){
            return true;
        }
        return false;


    }
  public bool CheckVertical(){
        if (Mathf.Abs(transform.position.x - firstPos.x) < error)
        {
            return true;
        }
        return false;


    }
    public bool CheckVertical1()
    {
        if (Mathf.Abs(transform.position.z - firstPos.x) < error)
        {
            return true;
        }
        return false;


    }


}




