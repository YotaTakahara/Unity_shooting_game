using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public float target_kmph_ = 100f; //時速100km
    public float tor = 4f;
    //[SerializeField] private RigidTakahara shin;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float hori;
    [SerializeField] private float vert;
    public float speed;
    public float shotSpeed;
   
    // public GameObject air;
    // private Rigidbody airScript;


    void Start()
    {
        // shin = GetComponent<RigidTakahara>();
        rb = GetComponent<Rigidbody>();
        // Debug.Log("jikkenndai" + shin.Velocity);
        // airScript = air.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float hori = Input.GetAxis("Horizontal")*10;
        float vert = Input.GetAxis("Vertical")*10;
        rb.AddRelativeTorque(new Vector3(0, hori, -hori));
        rb.AddRelativeTorque(new Vector3(vert, 0, 0));
        Vector3 left = transform.TransformVector(Vector3.left);
        Vector3 left_hori = new Vector3(left.x, 0, left.z).normalized;
        rb.AddTorque(Vector3.Cross(left, left_hori)*tor);
        Vector3 forward = transform.TransformVector(Vector3.forward);
        Vector3 forward_vert = new Vector3(0, forward.y, forward.z);
        rb.AddTorque(Vector3.Cross(forward, forward_vert));

        rb.AddRelativeForce(0, 0, shotSpeed);


        







    }


}




// void FixedUpdate()
// {
//     Debug.Log("rigidbody" + yotta);
//     Debug.Log("実験している上での速度" + shin.Velocity + " Rigidbodyの速度 " + yotta.velocity + "airの速度（Rigidbody)" +
//               airScript.velocity);
//     //  Debug.Log("実験している上での速度" + shin.Velocity + " Rigidbodyの速度 " + yotta.velocity);
//     //shin.AddForce(transform.forward * shotSpeed);
//     yotta.AddForce(transform.forward * shotSpeed);
//     transform.Translate(new Vector3(0, 0, speed));

//     transform.Translate(0, 0, 0.3f);
//     var hori = Input.GetAxis("Horizontal");
//     var vert = Input.GetAxis("Vertical");
//     var rb = GetComponent<Rigidbody>();
//     rb.AddRelativeTorque(new Vector3(0, hori, -hori));
//     rb.AddRelativeTorque(new Vector3(vert, 0, 0));
//     //左
//     var left = transform.TransformVector(Vector3.left);
//     var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;
//     rb.AddTorque(Vector3.Cross(left, horizontal_left) * tor);
//     //前方
//     var forward = transform.TransformVector(Vector3.forward);
//     var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
//     rb.AddTorque(Vector3.Cross(forward, horizontal_forward) * tor);
//     //前進
//     var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) /
//                 (1f - rb.drag * Time.fixedDeltaTime);
//     rb.AddRelativeForce(new Vector3(0f, 0f, force));
// }



