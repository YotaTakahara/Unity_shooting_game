using UnityEngine;

public class ColliderSphere : MonoBehaviour, ICollider, ISphere
{
    //private Vector3 _center = Vector3.zero;
    //修正要確認
    //コライダーのコードまじでぐちゃぐちゃ
    [SerializeField] private int damageChange=0;
    public Vector3 _center = new Vector3(0, 0, 0);
    public float k = 2 * 1.0f;


    public Vector3 Center
    {
        get { return _center; }
    }

    [SerializeField] private float _radius = 1.5f;

    public float Radius
    {
        get { return _radius; }
    }

    //  [SerializeField] private Transform _transform;


    private void Awake()
    {

        // _transform = this.transform;
        _radius = transform.localScale.y/2*k;/// 2 * k;
        // _radius = 15f;
    }

    public Vector3 WorldCenter
    {
        get { return transform.position + _center; }
    }


    public bool CheckSphere(ISphere collider)
    {
        var collideDistance = Radius + collider.Radius;
        // Debug.Log("collide.radius " + collider.Radius);
        // Debug.Log("Radius " + Radius);
        // Debug.Log("realDistance" + Vector3.Magnitude(WorldCenter - collider.WorldCenter));
        return (WorldCenter - collider.WorldCenter).sqrMagnitude <= collideDistance * collideDistance;
    }

    public bool CheckCube(ISphere collider)
    {
        return false;
    }

    void OnDrawGizmos()
    {
        if(damageChange==0){
            Gizmos.color = Color.red;
        }
        else if(damageChange==1){
            Gizmos.color = Color.green;
        }
        else if(damageChange==2){
            Gizmos.color = Color.blue;
        }
       
        Gizmos.DrawWireSphere(WorldCenter, _radius);
    }
}