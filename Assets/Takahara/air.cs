using UnityEngine;

public class air : MonoBehaviour
{
    private float miuTurnInputValue;
    private Rigidbody miuRb;

    private float miuNoseInputValue;
    public float speed;
    public int life = 3;
    public float stopTime = 0.5f;
    public float recoverTime = 0.0f;
    public GameObject fire;
    public int point = 0;
    public float shotSpeed;
    [SerializeField] private RigidTakahara yotta;

    bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0;
    }

    public int Life()
    {
        return life;
    }

    void Start()
    {
        miuRb = GetComponent<Rigidbody>();
        yotta = GetComponent<RigidTakahara>();
    }

    void FixedUpdate()
    {
        //   Debug.Log("ここよここmiuRb" + miuRb);
        if (IsStun())
        {
            //  miuRb.velocity = Vector3.zero;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            // 前進は自動
            transform.Translate(0f, 0f, speed);

            //yotta.AddForce(transform.forward * shotSpeed);
            //  Debug.Log("airの速さ " + miuRb.velocity);
            /*
             なんかよくわからないが、transformのままにしておいたほうが良さそう。結果としてAddForceが実装できたのでよかったとは思う。
             
             */

            // 旋回
            miuTurnInputValue = Input.GetAxis("Horizontal");

            if (Input.GetAxis("Horizontal") != 0)
            {
                //   Debug.Log("曲がるコマンド発動中");
            }

            //なんでそうなるのかまったくわからないんだが
            //macyou
            float turn = miuTurnInputValue * 100 * Time.deltaTime;
            //     Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            //turn = 100;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            // Debug.Log("turnRotation" + turnRotation);
            //Debug.Log("miuRb.rotation" + miuRb.rotation);
            // miuRb.MoveRotation(miuRb.rotation * turnRotation);
            yotta.MoveRotation(transform.rotation * turnRotation);
            //yotta.AddTorque(new Vector3(0, 10 * turn, 0));

            // 機首（上昇、下降）
            miuNoseInputValue = Input.GetAxis("Vertical");
            float noseTurn = miuNoseInputValue * 30 * Time.deltaTime;
            Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
            yotta.MoveRotation(transform.rotation * turnNoseRotation);
            //transform.rotation = (transform.rotation * turnNoseRotation);
            // miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);
            //   Debug.Log("speed:" + miuRb.velocity);y
            Debug.Log("speed:" + yotta.Velocity);
        }
    }

    public void Accident(GameObject other)
    {
        if (IsStun()) return;
        life--;
        recoverTime = stopTime;
        Debug.Log(life);
        Instantiate(fire, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}