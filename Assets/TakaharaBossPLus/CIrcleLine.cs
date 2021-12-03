using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CIrcleLine : MonoBehaviour
{
  [SerializeField] private GameObject player;
  [SerializeField] private float circleRadius;
  void Start()
  {
    player = GameObject.Find("AirPlane");
    // circleRadius = Vector3.Magnitude(transform.position - player.transform.position);

  }

  // Update is called once per frame
  void Update()
  {

  }
  void OnDrawGizmos()
  {
    Gizmos.color = Color.green;
    Vector3 where = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    Gizmos.DrawWireSphere(transform.position, circleRadius);
  }
}
