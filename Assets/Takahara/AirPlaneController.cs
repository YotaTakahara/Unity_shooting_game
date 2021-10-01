using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public float target_kmph_ = 100f; //時速100km
    public float tor = 4f;


    void Start()
    {
    }

    void FixedUpdate()
    {
        transform.Translate(0, 0, 0.3f);
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var rb = GetComponent<Rigidbody>();
        rb.AddRelativeTorque(new Vector3(0, hori, -hori));
        rb.AddRelativeTorque(new Vector3(vert, 0, 0));
        //左
        var left = transform.TransformVector(Vector3.left);
        var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;
        rb.AddTorque(Vector3.Cross(left, horizontal_left) * tor);
        //前方
        var forward = transform.TransformVector(Vector3.forward);
        var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontal_forward) * tor);
        //前進
        var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) /
                    (1f - rb.drag * Time.fixedDeltaTime);
        rb.AddRelativeForce(new Vector3(0f, 0f, force));
    }
}