using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirController : MonoBehaviour
{

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
    [SerializeField]private Rigidbody miuRb;

    [SerializeField] private RigidTakahara yotta;
    const int MinLane=-2;
    const int MaxLane = 2;
    const float LaneWidth = 1.0f*4;

    public Vector3 moveDirection = Vector3.zero;
    public int targetLane;
    public float speedZ;
    public float speedX;
    public float accelerationZ;



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

            Vector3 globalDirection = transform.TransformDirection(moveDirection);
            transform.Translate(globalDirection);
        }


    }
    public void MoveToLeft(){
        if(targetLane>MinLane)targetLane--;
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
        Debug.Log(life);
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
