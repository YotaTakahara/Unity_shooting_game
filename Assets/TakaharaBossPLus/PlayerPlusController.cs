using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlusController : MonoBehaviour
{
  [SerializeField] private GameObject boss;
  [SerializeField] private float radius = 60f;
  [SerializeField] private float speed = 0.4f;
  [SerializeField] private Vector3 center = Vector3.zero;
  [SerializeField] private float rad = 0f;

  float x;
  float y;
  float z;
  void Start()
  {
    radius = Vector3.Magnitude(new Vector3(boss.transform.position.x - transform.position.x, 0, boss.transform.position.z - transform.position.z));
    boss = GameObject.Find("Boss");

  }

  void FixedUpdate()
  {

    //Debug.Log("nanndeyanenn");
    if (Input.GetKey("left")) CircleRotation(-1);
    if (Input.GetKey("right")) CircleRotation(1);
    WhereToLook();
  }
  public void WhereToLook()
  {
    Vector3 diff = boss.transform.position - transform.position;
    Quaternion quaternion = Quaternion.LookRotation(diff);
    this.transform.rotation = quaternion;

  }
  public void CircleRotation(int check)
  {
    rad += (check) * speed * 2 * Mathf.PI / 360;
    x = radius * Mathf.Cos(rad);
    z = radius * Mathf.Sin(rad);
    transform.position = new Vector3(x + center.x, transform.position.y, z + center.z);
  }



}
