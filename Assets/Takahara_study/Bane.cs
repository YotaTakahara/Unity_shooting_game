using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bane : MonoBehaviour
{
    public Vector3 targetPosition;
    private Rigidbody rb;
    public float r;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = targetPosition - transform.position;
        rb.AddForce(diff * r);


    }
}
