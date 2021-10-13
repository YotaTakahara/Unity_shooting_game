using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    // [SerializeField] private GameObject _sphereObj;
    [SerializeField] private GameObject[] _target;
    [SerializeField] public ColliderSphere check;
    [SerializeField] private GameObject air;
    [SerializeField] private GameObject attackList;
    [SerializeField] private List<GameObject> attack;


    private ISphere _sphere;
    private bool _didCollide;
    public GameObject fire;

    private void Awake()
    {
        air = GameObject.Find("AirPlane");
        //_targetColliderRoot = GameObject.Find("Monsters");
        _target = GameObject.FindGameObjectsWithTag("Monster");

        _sphere = GetComponent<ISphere>();

        attackList = GameObject.Find("attackList");
        attack = attackList.GetComponent<List>().attack;

        //  _colliders = _targetColliderRoot.GetComponentsInChildren<ICollider>();
        //   _colliders = _targetColliderRoot.GetComponentsInChildren<ICollider>();
        // Debug.Log("targetが取得できたか" + _target.Length);
        // Debug.Log("_sphere"+_sphere);
    }


    private void Update()
    {
        _didCollide = false;
        if (_sphere != null && _target != null)
        {
            // Debug.Log("ここまでは順調です");
            for (int i = 0; i < _target.Length; i++)
            {
                if (_target[i] != null)
                {
                    // _didCollide |= _colliders[i].CheckSphere(_sphere);
                    ColliderSphere shin = _target[i].GetComponent<ColliderSphere>();
                    _didCollide = shin.CheckSphere(_sphere);
                    //   Debug.Log("中身はどうですか" + _target[i]);
                    //Debug.Log("_didCollideの中身" + _didCollide);
                    if (_didCollide)
                    {
                        Instantiate(fire, transform.position, Quaternion.identity);
                        // int index = attack.IndexOf(_target[i]);
                        // attack.RemoveAt(index);
                        Destroy(_target[i]);
                        air airScript = air.GetComponent<air>();
                        airScript.point += 1;

                        Debug.Log("無事衝突判定ができました");
                    }
                }
            }
        }
    }
}