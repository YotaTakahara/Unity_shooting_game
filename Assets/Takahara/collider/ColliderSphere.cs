using UnityEngine;

public class ColliderSphere : MonoBehaviour, ICollider, ISphere
{
    private Vector3 _center = Vector3.zero;

    public Vector3 Center
    {
        get { return _center; }
    }

    public float _radius = 0.7f;

    public float Radius
    {
        get { return _radius; }
    }

    //  [SerializeField] private Transform _transform;


    private void Awake()
    {
        // _transform = this.transform;
    }

    public Vector3 WorldCenter
    {
        get { return transform.position + _center; }
    }


    public bool CheckSphere(ISphere collider)
    {
        var collideDistance = Radius + collider.Radius;
        return (WorldCenter - collider.WorldCenter).sqrMagnitude <= collideDistance * collideDistance;
    }
}