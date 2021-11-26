using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPoint : MonoBehaviour
{
    // [SerializeField] private RectTransform _markerPanel;
    // [SerializeField] private ObjectMarker _markerPrefab;
    [SerializeField] private UIController uiController;

    [SerializeField] private GameObject canvas;
        public GameObject attackList;
    public List list;

    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        //canvas = GameObject.Find("Canvas");
        
        GameObject uiTmp = GameObject.Find("UIController");
        uiController = uiTmp.GetComponent<UIController>();




        GameObject go = (GameObject)Instantiate(prefab, Vector3.zero, Quaternion.identity);
        //Debug.Log("go:" + go);
        uiController.UIInstance(go);
        //CallInitialize(go.transform);
        // if(prefab.gameObject.tag=="Monster"){
        //     GameObject tmpImage = (GameObject)Instantiate(image, Vector3.zero, Quaternion.identity);
        //     UIFollowTarget target = image.GetComponent<UIFollowTarget>();
        //     target.target = go.transform;
        //     tmpImage.transform.SetParent(canvas.transform, false);
        // }
        // var marker = Instantiate(_markerPrefab, _markerPanel);
        // marker.Initialize(go.transform);


        attackList = GameObject.Find("attackList");
        list = attackList.GetComponent<List>();
        list.attack.Add(go);


        go.transform.SetParent(transform, false);
    }
    public void CallInitialize(Transform target){

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
