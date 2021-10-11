using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    [SerializeField] private GameObject _sphereObj;
    [SerializeField] private GameObject _targetColliderRoot;

    private ISphere _sphere;
    private ICollider[] _colliders;
    private bool _didCollide;
    public GameObject fire;

    private void Awake()
    {
        _targetColliderRoot = GameObject.Find("Monsters");
        _sphere = _sphereObj.GetComponent<ISphere>();
        // _colliders = _targetColliderRoot.GetComponentsInChildren<ICollider>();
        //   _colliders = _targetColliderRoot.GetComponentsInChildren<ICollider>();
        Debug.Log("targetが取得できたか" + _targetColliderRoot);
        Debug.Log("いやなんでやねん");
    }


    private void Update()
    {
        _didCollide = false;
        if (_sphere != null && _colliders != null)
        {
            for (int i = 0; i < _colliders.Length; i++)
            {
                _didCollide |= _colliders[i].CheckSphere(_sphere);
                Debug.Log("中身はどうですか" + _colliders[i]);
                Debug.Log("_didCollideの中身" + _didCollide);
                if (_didCollide)
                {
                    Instantiate(fire, transform.position, Quaternion.identity);
                    Debug.Log("無事衝突判定ができました");
                }
            }
        }
    }
}