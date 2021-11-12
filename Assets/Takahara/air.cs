using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class air : MonoBehaviour
{
    public float speed = 0.4f;

    public int life = 3;
    //hennkou 
    public int hp = 100;
    //hennkou 
    public float stopTime = 0.5f;
    public float recoverTime = 0.0f;
    public GameObject fire;
    public GameObject explosion;
    public int point = 0;
    public float shotSpeed;
    [SerializeField] private GameObject stage;
    [SerializeField] private sstageGenerator sstageGenerator;
    [SerializeField] private Rigidbody miuRb;

    [SerializeField] private RigidTakahara yotta;
    const int MinLane = -2;
    const int MaxLane = 2;
    public float LaneWidth = 1.0f * 4;

    public Vector3 moveDirection = Vector3.zero;
    public int targetLane;
    public float speedZ;
    public float speedX;
    public float accelerationZ;
    public Vector3 globalDirection;



    bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0 || hp <= 0;
    }

    public int Life()
    {
        return life;
    }
    //hennkou
    public int HP()
    {
        return hp;
    }
    //hennkou



    void Start()
    {
        stage = GameObject.Find("StageGenerator");
        sstageGenerator = stage.GetComponent<sstageGenerator>();
        LaneWidth = sstageGenerator.LaneWidth;

        miuRb = GetComponent<Rigidbody>();
        yotta = GetComponent<RigidTakahara>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsStun())
        {
            //  miuRb.velocity = Vector3.zero;
            recoverTime -= Time.deltaTime;
        }
        else
        {

            if (Input.GetKeyDown("left")) MoveToLeft();
            if (Input.GetKeyDown("right")) MoveToRight();

            float accZ = moveDirection.z + accelerationZ * Time.deltaTime;
            moveDirection.z = Mathf.Clamp(accZ, 0, speedZ);

            float ratioX = (targetLane * LaneWidth - transform.position.x) / LaneWidth;
            moveDirection.x = ratioX * speedX;

            globalDirection = transform.TransformDirection(moveDirection);
            transform.Translate(globalDirection);
            // tmpSpeed = globalDirection;
            // Debug.Log("tmpSpeed by airplane:" + tmpSpeed);
        }


    }
    public void MoveToLeft()
    {
        if (targetLane > MinLane) targetLane--;
    }
    public void MoveToRight()
    {
        if (targetLane < MaxLane) targetLane++;
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

    public void AccidentStrong()
    {
        if (IsStun()) return;
        life--;
        recoverTime = stopTime;
        //Debug.Log(life);
        Instantiate(explosion, transform.position, Quaternion.identity);

    }
    //hennkou 
    public void AccidentBossDamage(int str)
    {
        life--;
        hp -= str;
        Debug.Log(hp);
        Instantiate(explosion, transform.position, Quaternion.identity);

    }
    public void GameOverScene()
    {

    }

}














// using UnityEngine;

// public class air : MonoBehaviour
// {
//     private float miuTurnInputValue;
//     private Rigidbody miuRb;

//     private float miuNoseInputValue;
//     public float speed;
//     public int life = 3;
//     //hennkou 
//     public int hp = 100;
//     //hennkou 
//     public float stopTime = 0.5f;
//     public float recoverTime = 0.0f;
//     public GameObject fire;
//     public GameObject explosion;
//     public int point = 0;
//     public float shotSpeed;
//     [SerializeField] private RigidTakahara yotta;

//     bool IsStun()
//     {
//         return recoverTime > 0.0f || life <= 0 || hp <= 0;
//     }

//     public int Life()
//     {
//         return life;
//     }
//     //hennkou
//     public int HP()
//     {
//         return hp;
//     }
//     //hennkou

//     void Start()
//     {
//         miuRb = GetComponent<Rigidbody>();
//         yotta = GetComponent<RigidTakahara>();
//     }

//     void FixedUpdate()
//     {
//         //   Debug.Log("ここよここmiuRb" + miuRb);
//         if (IsStun())
//         {
//             //  miuRb.velocity = Vector3.zero;
//             recoverTime -= Time.deltaTime;
//         }
//         else
//         {
//             // 前進は自動
//             transform.Translate(0f, 0f, speed);

//             //yotta.AddForce(transform.forward * shotSpeed);
//             //  Debug.Log("airの速さ " + miuRb.velocity);
//             /*
//              なんかよくわからないが、transformのままにしておいたほうが良さそう。結果としてAddForceが実装できたのでよかったとは思う。

//              */

//             // 旋回
//             miuTurnInputValue = Input.GetAxis("Horizontal");

//             if (Input.GetAxis("Horizontal") != 0)
//             {
//                 //   Debug.Log("曲がるコマンド発動中");
//             }

//             //なんでそうなるのかまったくわからないんだが
//             //macyou
//             float turn = miuTurnInputValue * 100 * Time.deltaTime;
//             //     Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
//             //turn = 100;
//             Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
//             // Debug.Log("turnRotation" + turnRotation);
//             //Debug.Log("miuRb.rotation" + miuRb.rotation);
//             // miuRb.MoveRotation(miuRb.rotation * turnRotation);
//             yotta.MoveRotation(transform.rotation * turnRotation);
//             //yotta.AddTorque(new Vector3(0, 10 * turn, 0));

//             // 機首（上昇、下降）
//             miuNoseInputValue = Input.GetAxis("Vertical");
//             float noseTurn = miuNoseInputValue * 30 * Time.deltaTime;
//             Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
//             yotta.MoveRotation(transform.rotation * turnNoseRotation);
//             //transform.rotation = (transform.rotation * turnNoseRotation);
//             // miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);
//             //   Debug.Log("speed:" + miuRb.velocity);y
//             // Debug.Log("speed:" + yotta.Velocity);
//         }
//     }


//     public void Accident(GameObject other)
//     {
//         if (IsStun()) return;
//         life--;
//         recoverTime = stopTime;
//         Debug.Log(life);
//         Instantiate(fire, transform.position, Quaternion.identity);
//         Destroy(other.gameObject);
//     }

//     public void AccidentStrong()
//     {
//         if (IsStun()) return;
//         life--;
//         recoverTime = stopTime;
//         Debug.Log(life);
//         Instantiate(explosion, transform.position, Quaternion.identity);

//     }
//     //hennkou 
//     public void AccidentBossDamage(int str)
//     {
//         life--;
//         hp -= str;
//         Debug.Log(hp);
//         Instantiate(explosion, transform.position, Quaternion.identity);

//     }
//     public void GameOverScene()
//     {

//     }

//     //hennkou
// }