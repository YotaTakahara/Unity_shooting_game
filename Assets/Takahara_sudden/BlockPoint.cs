using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPoint : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    [SerializeField] private GameObject canvas;
    
    public GameObject attackList;
    public List list;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");

        GameObject uiTmp = GameObject.Find("UIController");
        uiController = uiTmp.GetComponent<UIController>();
        Vector3 tmpSize = new Vector3(0, transform.localScale.y, 0);
        GameObject go = (GameObject)Instantiate(prefab, tmpSize, Quaternion.identity);
        Debug.Log("go:" + go);
        attackList = GameObject.Find("attackList");
        list = attackList.GetComponent<List>();
        list.obstacle.Add(go);
        go.transform.SetParent(transform, false);

    }

    void OnDrawGizmos()
    {
        Vector3 offset = new Vector3(0, 2.5f, 0);
        Gizmos.color = new Color(0, 0.8f, 0, 0.5f);
        Gizmos.DrawCube(transform.position + offset, new Vector3(5,5,2));
        
    }

    

    
    void Update()
    {
        
    }
}
