using UnityEngine;

public class RigidTakahara : MonoBehaviour
{
    public Vector3 position;
    public Calc prePosition;
    public float mass = 1.0f;
    public float k = 1.0f;

    Rigidbody rigid;


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
        Vector3 acceleration = force / mass;
        this.Velocity += acceleration * Time.deltaTime;
        transform.Translate(this.Velocity * Time.deltaTime);
        Debug.Log("acceleration " + acceleration + " velocity " + this.Velocity + " force " + force);
    }
    public void MoveRotation(Quaternion turn){
        this.transform.rotation = turn;


    }
    public void AddTorque(Vector3 vect){
        Quaternion R = transform.rotation*rigid.inertiaTensorRotation;
        Vector3 I = rigid.inertiaTensor;
        rigid.angularVelocity += R * Vector3.Scale(Reciprocal(I), Quaternion.Inverse(R) * vect) * Time.deltaTime;


    }
    public Vector3 Reciprocal(Vector3 v){
        return new Vector3(1 / v.x, 1 / v.y, 1 / v.z);
    }
}

public class Calc
{
    public Calc(Vector3 pre)
    {
        prePosition = pre;
    }

    public Vector3 prePosition { get; set; }
}