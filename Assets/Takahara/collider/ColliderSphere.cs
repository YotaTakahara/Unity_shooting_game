using UnityEngine;

public class ColliderSphere : MonoBehaviour, ICollider, ISphere
{
    //private Vector3 _center = Vector3.zero;
    //修正要確認
    //コライダーのコードまじでぐちゃぐちゃ
    [SerializeField] private int damageChange = 1;
    //[SerializeField] private 
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
        float a = transform.lossyScale.y;
        if(a<transform.lossyScale.x){
            a = transform.lossyScale.x;
        }
        if(a<transform.lossyScale.z){
            a = transform.lossyScale.z;
        }
        _radius = a/2*k;/// 2 * k;
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
        if (damageChange == 0)
        {
            Gizmos.color = Color.red;
        }
        else if (damageChange == 1)
        {
            Gizmos.color = Color.green;
        }
        else if (damageChange == 2)
        {
            Gizmos.color = Color.blue;
        }

        Gizmos.DrawWireSphere(WorldCenter, _radius);
    }

    public int CheckCapsuleCollision(Vector3 playerPlace, Vector3 localPoint, float maxLen, float maxSeLen)
    {
        Vector3 diffPosition = WorldCenter - playerPlace;
        Vector3 relativePosition = transform.InverseTransformDirection(diffPosition);
        float naiseki = Vector3.Dot(relativePosition, localPoint);
        float absN = Mathf.Abs(naiseki);
        // Debug.Log("localMyPlace " + localDiffPlace+ " naiseki " + naiseki+ " localPoint " + localPoint);

        if (maxLen + Radius < absN)
        {
            return 0;
        }
        else
        {
            if (maxLen - maxSeLen <= absN && absN <= maxLen + Radius)
            {
                Vector3 circleCenter = (maxLen - maxSeLen) * localPoint * naiseki / (Mathf.Abs(naiseki));
                Vector3 circleDistance = circleCenter - relativePosition;
                //  Debug.Log("circleCenter " + circleCenter + " circleDistance " + circleDistance.magnitude +
                //            " ene.transform.localScale.x " +
                //            ene.transform.localScale.x);
                if (circleDistance.magnitude < Radius + maxSeLen)
                {
                    /*どうあがいても円判定の実装がおかしいので早めになおしておく*/
                    Debug.Log("円判定");
                    // Debug.Log("this:"+this);
                    // Debug.Log("そっちかい");
                    return damageChange;
                }
            }

            if (absN < maxLen - maxSeLen)
            {
                Vector3 line = naiseki * localPoint;
                Vector3 lineDistance = line - relativePosition;
                //  Debug.Log("line " + line + " lineDistance " + lineDistance.magnitude + " ene.transform.localScale.x " +
                //           ene.transform.localScale.x);

                if (lineDistance.magnitude < Radius + maxSeLen)
                {
                    // Debug.Log("カプセル判定");
                    // Debug.Log("this:" + this);
                    // Debug.Log("そっちかい");
                    return damageChange;
                }
            }
        }

        return 0;
    }





    // public bool CheckCapsuleCollision(Vector3 playerPlace, Vector3 localPoint, float maxLen, float maxSeLen)
    // {
    //     Vector3 diffPosition = WorldCenter - playerPlace;
    //     Vector3 relativePosition = transform.InverseTransformDirection(diffPosition);
    //     float naiseki = Vector3.Dot(relativePosition, localPoint);
    //     float absN = Mathf.Abs(naiseki);
    //     // Debug.Log("localMyPlace " + localDiffPlace+ " naiseki " + naiseki+ " localPoint " + localPoint);

    //     if (maxLen + Radius < absN)
    //     {
    //         return false;
    //     }
    //     else
    //     {
    //         if (maxLen - maxSeLen <= absN && absN <= maxLen + Radius)
    //         {
    //             Vector3 circleCenter = (maxLen - maxSeLen) * localPoint * naiseki / (Mathf.Abs(naiseki));
    //             Vector3 circleDistance = circleCenter - relativePosition;
    //             //  Debug.Log("circleCenter " + circleCenter + " circleDistance " + circleDistance.magnitude +
    //             //            " ene.transform.localScale.x " +
    //             //            ene.transform.localScale.x);
    //             if (circleDistance.magnitude < Radius + maxSeLen)
    //             {
    //                 /*どうあがいても円判定の実装がおかしいので早めになおしておく*/
    //                 Debug.Log("円判定");
    //                 // Debug.Log("this:"+this);
    //                 // Debug.Log("そっちかい");
    //                 return true;
    //             }
    //         }

    //         if (absN < maxLen - maxSeLen)
    //         {
    //             Vector3 line = naiseki * localPoint;
    //             Vector3 lineDistance = line - relativePosition;
    //             //  Debug.Log("line " + line + " lineDistance " + lineDistance.magnitude + " ene.transform.localScale.x " +
    //             //           ene.transform.localScale.x);

    //             if (lineDistance.magnitude < Radius + maxSeLen)
    //             {
    //                 // Debug.Log("カプセル判定");
    //                 // Debug.Log("this:" + this);
    //                 // Debug.Log("そっちかい");
    //                 return true;
    //             }
    //         }
    //     }

    //     return false;
    // }










}