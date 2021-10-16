using UnityEngine;

public class AirPlaneController : MonoBehaviour
{
    public float target_kmph_ = 100f; //時速100km
    public float tor = 4f;
    [SerializeField] private RigidTakahara shin;
    [SerializeField] private Rigidbody yotta;
    public float speed;
    public float shotSpeed;
    public GameObject air;
    private Rigidbody airScript;


    void Start()
    {
        shin = GetComponent<RigidTakahara>();
        yotta = GetComponent<Rigidbody>();
        Debug.Log("jikkenndai" + shin.Velocity);
        airScript = air.GetComponent<Rigidbody>();
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
    void FixedUpdate()
    {
        yotta.AddForce(transform.forward * shotSpeed);
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var rb = GetComponent<Rigidbody>();

        //自分に対しての向きで、トルクをかける
        rb.AddRelativeTorque(new Vector3(0, hori, -hori) * 2f); //左右でy軸回転
        rb.AddRelativeTorque(new Vector3(vert, 0, -vert) * 2f); //上下でx軸回転

        //x軸方向の水平を保つ
        var left = transform.TransformVector(Vector3.left); //機体の左を向くベクトルを、ローカル→ワールド座標に変換する！
        var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;   //上で求めたベクトルをx-z平面（水平）上のベクトルに補正し、単位ベクトルにする。
        rb.AddTorque(Vector3.Cross(left, horizontal_left) * 6f);    //外積を取る。傾いているほど大きいトルク。（ばねのように）

        //機体から見てz軸方向にも水平を保つ。
        var forward = transform.TransformVector(Vector3.forward);
        var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontal_forward) * 6f);

        //機体を前に発進させるエンジン
        var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) / (1f - rb.drag * Time.fixedDeltaTime);   //ある終端そくどに向かうための力を求める！
        rb.AddRelativeForce(new Vector3(0f, 0f, force));
    }
}