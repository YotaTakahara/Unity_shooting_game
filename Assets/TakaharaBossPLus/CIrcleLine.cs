using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLine : MonoBehaviour
{
  [SerializeField] private GameObject player;
  [SerializeField] private float circleRadius;
  public  Vector3 zurashi;
   // Vector3 firstPos;
    void Start()
  {
    player = GameObject.Find("AirPlane");
        //firstPos = transform.position;
        // circleRadius = Vector3.Magnitude(transform.position - player.transform.position);

    }

  // Update is called once per frame
  void Update()
  {

  }
  void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
  //  Vector3 where = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Gizmos.DrawWireSphere(transform.position+zurashi, circleRadius);
  }
}
