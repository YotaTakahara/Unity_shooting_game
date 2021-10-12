using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCapsule : MonoBehaviour
{
    [SerializeField] GameObject[] enemy;
    private bool _didCollide;



    public void size()
    {
    float x = transform.localScale.x;
    float y = transform.localScale.y;
    float z = transform.localScale.z;

    }
    // Start is called before the first frame update
    void Start()
    {
    enemy = GameObject.FindGameObjectsWithTag("Monster");

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
