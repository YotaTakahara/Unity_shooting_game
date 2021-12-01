using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPoint : ControllerBase
{

    [SerializeField] private GameObject canvas;
    public GameObject prefab;
    [Space]
    [SerializeField] private bool isGizmosOn = false;

    void Start()
    {
        canvas = GameObject.Find("Canvas");


        Vector3 tmpSize = new Vector3(0, transform.localScale.y, 0);
        GameObject go = (GameObject)Instantiate(prefab, tmpSize, Quaternion.identity);
        Debug.Log("go:" + go);
        list.obstacle.Add(go);
        go.transform.SetParent(transform, false);

    }

    void OnDrawGizmos()
    {
        if (isGizmosOn == true)
        {
            Vector3 offset = new Vector3(0, 2.5f, 0);
            Gizmos.color = new Color(0, 0.8f, 0, 0.5f);
            Gizmos.DrawCube(transform.position + offset, new Vector3(5, 5, 2));
        }

    }




    void Update()
    {

    }
}
