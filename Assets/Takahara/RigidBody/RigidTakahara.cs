using UnityEngine;

public class RigidTakahara : MonoBehaviour
{
    [SerializeField] private Vector3 position;
    [SerializeField] private Calc prePosition;
    public float mass = 1.0f;
    public float k = 1.0f;
    public bool isdrag = false;
    public Vector3 finalSpeed;

    Rigidbody rigid;

    //手直し＋αでangularDragを実装しておくとよりよい
    //手直し；クラス自体の書き換えを行う


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        prePosition = new Calc(transform.position);
        this.Velocity = new Vector3(0, 0, 0);
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 diff = (transform.position - prePosition.prePosition) / Time.deltaTime;
        this.Velocity = diff;
        prePosition.prePosition = transform.position;
    }

    public Vector3 Velocity { get; set; }

    public void AddForce(Vector3 force)
    {
        // k = force.z / finalSpeed.z;
        Debug.Log("finalSpeed" + finalSpeed.z);
        Vector3 acceleration;
        //acceleration = force / mass;
        if (isdrag == true)
        {
            acceleration = (force - k * this.Velocity) / mass;
        }
        else
        {
            acceleration = force / mass;
        }

        acceleration = force / mass;

        this.Velocity += acceleration * Time.deltaTime;
        transform.Translate(this.Velocity * Time.deltaTime);
        Debug.Log("acceleration " + acceleration + " velocity " + this.Velocity + " force " + force);
    }

    public void AddRelativeForce(Vector3 force)
    {
        force = transform.TransformVector(force);
        Vector3 acceleration = force / mass;
        this.Velocity += acceleration * Time.deltaTime;
        transform.Translate(this.Velocity * Time.deltaTime);
        Debug.Log("acceleration " + acceleration + " velocity " + this.Velocity + " force " + force);
    }


    public void MoveRotation(Quaternion turn)
    {
        this.transform.rotation = turn;
    }

    //手直し必要 慣性トルクについての扱いをしっかりしておく
    public void AddTorque(Vector3 vect)
    {
        Quaternion R = transform.rotation * rigid.inertiaTensorRotation;
        Vector3 I = rigid.inertiaTensor;
        rigid.angularVelocity += R * Vector3.Scale(Reciprocal(I), Quaternion.Inverse(R) * vect) * Time.deltaTime;
    }

    public void AddRelativeTorque(Vector3 vect)
    {
        Vector3 vectWorld = transform.TransformVector(vect);
        Quaternion R = transform.rotation * rigid.inertiaTensorRotation;
        Vector3 I = rigid.inertiaTensor;
        rigid.angularVelocity += R * Vector3.Scale(Reciprocal(I), Quaternion.Inverse(R) * vectWorld) * Time.deltaTime;
    }

    public Vector3 Reciprocal(Vector3 v)
    {
        return new Vector3(1 / v.x, 1 / v.y, 1 / v.z);
    }
}
//ここまでて直し

public class Calc
{
    public Calc(Vector3 pre)
    {
        prePosition = pre;
    }

    public Vector3 prePosition { get; set; }
}