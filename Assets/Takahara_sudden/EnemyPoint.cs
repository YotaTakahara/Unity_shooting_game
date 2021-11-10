using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoint : MonoBehaviour
{
    public GameObject attackList;
    public List list;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {


        GameObject go = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);

        attackList = GameObject.Find("attackList");
        list = attackList.GetComponent<List>();
        list.attack.Add(go);


        go.transform.SetParent(transform, false);
    }
    void OnDrawGizmos()
    {
        Vector3 offset = new Vector3(0, 0.5f, 0);
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 2f);
        if (prefab != null)
        {
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
        }
    }
}
