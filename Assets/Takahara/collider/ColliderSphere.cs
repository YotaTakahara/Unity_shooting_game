using UnityEngine;

public class ColliderSphere : MonoBehaviour, ICollider, ISphere
{
    private Vector3 _center = Vector3.zero;

    public Vector3 Center
    {
        get { return _center; }
    }

    [SerializeField] private float _radius;

    public float Radius
    {
        get { return _radius; }
    }

    //  [SerializeField] private Transform _transform;


    private void Awake()
    {
        // _transform = this.transform;
        _radius = transform.localScale.x;
        // _radius = 15f;
    }

    public Vector3 WorldCenter
    {
        get { return transform.position + _center; }
    }


    public bool CheckSphere(ISphere collider)
    {
        var collideDistance = Radius + collider.Radius;
        Debug.Log("collide.radius " + collider.Radius);
        Debug.Log("Radius " + Radius);
        Debug.Log("realDistance" + Vector3.Magnitude(WorldCenter - collider.WorldCenter));
        return (WorldCenter - collider.WorldCenter).sqrMagnitude <= collideDistance * collideDistance;
    }
}