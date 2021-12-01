using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPoint : ControllerBase
{
    [SerializeField] private GameObject canvas;
    public GameObject prefab;
    [Space]
    [SerializeField] private bool isGizmosOn = false;
    GameObject go;


    void Start()
    {
        go = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);

        uiController.UIInstance(go);
        //CallInitialize(go.transform);

        list.attack.Add(go);


        go.transform.SetParent(transform, false);
    }
    public void Update()
    {
        float deathDistance = transform.position.z - player.transform.position.z;
        if (deathDistance < -3.0f)
        {
            list.attack.Remove(go.gameObject);


        }

    }
    public void CallInitialize(Transform target)
    {

    }
    void OnDrawGizmos()
    {
        if (isGizmosOn == true)
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
}
