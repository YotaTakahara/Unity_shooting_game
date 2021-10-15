using UnityEngine;

public class RigidTakahara : MonoBehaviour
{
    public Vector3 position;
    public Calc prePosition;
    public float mass = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        prePosition = new Calc(transform.position);
        this.Velocity = new Vector3(0, 0, 0);
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
}

public class Calc
{
    public Calc(Vector3 pre)
    {
        prePosition = pre;
    }

    public Vector3 prePosition { get; set; }
}