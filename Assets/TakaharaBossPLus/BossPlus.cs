using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public enum BossPlusState{

}


public class BossPlus:MonoBehaviour
{
    [SerializeField] private GameObject bull;
    [SerializeField] private Vector3 center;
    [SerializeField] private float radius;
    [SerializeField] private GameObject player;
    [SerializeField] private int shootStyle = 3;
    public float span = 2.0f;
    public int power = 500;
    public int bullNum;
    float deg;
    float tmpSpan = 0;
    List<GameObject> bullList = new List<GameObject>();

    void Start()
    {
        player = GameObject.Find("AirPlane");
        
        deg = 2 * Mathf.PI / bullNum;
        bull = (GameObject)Resources.Load("EnemyBullet1");
        if (shootStyle == 1)
        {
            StartCoroutine(Shoot1());
        }
        else if (shootStyle == 2)
        {
            StartCoroutine(Shoot2());
        }
        else if (shootStyle == 3)
        {
            StartCoroutine(Shoot3());
        }
        else if (shootStyle == 4)
        {
            StartCoroutine(Shoot4());
        }


    }

    // Update is called once per frame
    void Update()
    {
       


    }
    public float GetAim()
    {
        float dx = player.transform.position.x - this.transform.position.x;
        float dy = player.transform.position.y - this.transform.position.y;
        return Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
    }
    public void InstantiateAndShoot(Vector3 pos)
    {
        GameObject shot = (GameObject)Instantiate(bull, pos, Quaternion.identity);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        Vector3 shotDirection = new Vector3(shot.transform.position.x - center.x, shot.transform.position.y - center.y, shot.transform.position.z-center.z);
        rb.AddForce(shotDirection.normalized * power);

    }

    public IEnumerator Shoot1()
    {
        while (true)
        {
            for (int i = 0; i < bullNum; i++)
            {
                float rad = i * deg;
                float cos = Mathf.Cos(rad);
                float sin = Mathf.Sin(rad);
                Vector3 pos = center + new Vector3(cos, 0,sin);
                InstantiateAndShoot(pos);
            }
            yield return new WaitForSeconds(span);
        }
    }
    public IEnumerator Shoot2()
    {
        float baseDirection = GetAim();
        int count = 0;
        while (true)
        {
            float dir = baseDirection + Mathf.Sin(10 * count * Mathf.Deg2Rad) * 30;
            for (int i = -1; i < 2; i++)
            {
                float rad = (dir + i * 30) * 2 * Mathf.PI / 360;
                float cos = Mathf.Cos(rad);
                float sin = Mathf.Sin(rad);
                Vector3 pos = center + new Vector3(cos, 0, sin);
                InstantiateAndShoot(pos);

            }
            yield return new WaitForSeconds(0.3f);

            count++;
        }

    }
    public IEnumerator Shoot3()
    {

        while (true)
        {
            float rad = 0;
            while (rad < 2 * Mathf.PI)
            {
                rad += 2 * Mathf.PI * 8 / 360;
                float cos = Mathf.Cos(rad);
                float sin = Mathf.Sin(rad);
                Vector3 pos = center + new Vector3(cos, sin, 0);
                InstantiateAndShoot(pos);
                yield return new WaitForSeconds(0.1f);


            }
            yield return new WaitForSeconds(5.0f);
        }
    }
    public IEnumerator Shoot4()
    {
        while (true)
        {
            float rad = GetAim() * 2 * Mathf.PI / 360;
            for (int i = 0; i < 10; i++)
            {
                float cos = Mathf.Cos(rad);
                float sin = Mathf.Sin(rad);
                Vector3 pos = center + new Vector3(cos, sin, 0);
                InstantiateAndShoot(pos);
                yield return new WaitForSeconds(0.08f);

            }
            yield return new WaitForSeconds(1.0f);
        }

    }
    public void Shoot()
    {
        for (int i = 0; i < bullNum; i++)
        {
            float rad = i * deg;
            float cos = Mathf.Cos(rad);
            float sin = Mathf.Sin(rad);

            Vector3 pos = center + new Vector3(cos * radius, sin * radius, 0);
            GameObject shot = Instantiate(bull, pos, Quaternion.identity);
            shot.gameObject.SetActive(false);
            bullList.Add(shot);

        }

        foreach (GameObject bullet in bullList)
        {
            bullet.gameObject.SetActive(true);
            Vector3 shotDirection = new Vector3(bullet.transform.position.x - center.x, bullet.transform.position.y - center.y, 0);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(shotDirection.normalized * power);


        }
        bullList.Clear();

    }

}













// namespace Ai
// {

//     public enum BossPlusState
//     {
//         wander,
//         attack,

//         explode,
//     }

//     public class StateMachineBoss : StateMachine<BossPlus>
//     {
//     }

//     public class BossPlus : StatefulObjectBase<BossPlus, BossPlusState>
//     {
//         // private int maxLife = 3;
//         // private int life;
//         //
//         // private float speed = 10f;
//         // private float rotationSmooth = 1f;
//         // private float turretRotationSmooth = 0.8f;
//         // private float attackInterval = 2f;
//         //
//         // private float pursuitSqrDistance = 2500f;
//         // private float attackSqrDistance = 900f;
//         // private float margin = 50f;
//         //
//         // private float changeTargetSqrDistance = 40f;

//         //疑問：一緒にMonoBehaviourを継承できない 
//         [SerializeField] private Animator animator;
//         [SerializeField] private GameObject bullet;
//         [SerializeField] private GameObject explode;
//         [SerializeField] private GameObject player;
//         [SerializeField] private air air;

//         [SerializeField] public float speed = 2.0f;
//         // [SerializeField] private GameObject stageGeneratorTmp;
//         //[SerializeField] private StageGenerator stageGenerator;
//         //[SerializeField] private float LaneWidth;
//         //[SerializeField] private List list;
//         [SerializeField] private PointAdder pointAdder;
//         [Space]


//         public float HP = 100;
//         public int defeatScore = 20;
//         // public GameObject damage;


//         void Start()
//         {
//             player = GameObject.Find("AirPlane");
//             air = player.GetComponent<air>();
//             animator = GetComponent<Animator>();
//             //stageGeneratorTmp = GameObject.Find("StageGenerator");
//             //stageGenerator = stageGeneratorTmp.GetComponent<StageGenerator>();
//             //LaneWidth = stageGenerator.LaneWidth;
//             //GameObject listTmp = GameObject.Find("AttackList");
//             //list = listTmp.GetComponent<List>();
//             GameObject addTmp = GameObject.Find("PointAdder");
//             pointAdder = addTmp.GetComponent<PointAdder>();
//             //  bullet = GameObject.FindGameObjectWithTag("BossPlusBullet");
//             //Debug.Log("player " + player);


//             Initialize();
//         }

//         public void Initialize()
//         {
//             StateWander stateWander = this.gameObject.AddComponent<StateWander>();
//             stateWander.owner = this;

//             //Debug.Log("airplane really find??" + stateWander.owner);
//             // StatePursuit statePursuit = this.gameObject.AddComponent<StatePursuit>();
//             // statePursuit.owner = this;
//             StateAttack stateAttack = this.gameObject.AddComponent<StateAttack>();
//             stateAttack.owner = this;
//             StateExplode stateExplode = this.gameObject.AddComponent<StateExplode>();
//             stateExplode.owner = this;
//             //Debug.Log("stateWander" + stateWander.owner);


//             stateList.Add(stateWander);
//             //stateList.Add(statePursuit);
//             stateList.Add(stateAttack);
//             stateList.Add(stateExplode);
//             // Debug.Log("stageList " + stageList);
//             stateMachine = this.gameObject.AddComponent<StateMachineBoss>();
//             BossPlusState first = BossPlusState.wander;
//             //stateMachine = new StateMachine<BossPlus>();
//             // Debug.Log("stateMachine" + stateMachine);
//             // Debug.Log("first" + first);
//             ChangeStateNext((int)first);
//         }

//         public void TakeDamage()
//         {
//             this.HP -= 1;
//             //Debug.Log("HPダメージ判定に成功しました、残りのHP:" + HP);
//             if (this.HP <= 0)
//             {
//                 //Debug.Log("ここは呼ばれてるで");
//                 int index = (int)BossPlusState.explode;
//                 ChangeStateNext(index);
//             }
//         }
//         // public override void FixedUpdate()
//         // {
//         //     float deathDistance = this.transform.position.z - player.transform.position.z;
//         //     if(deathDistance<-5f){
//         //         list.attack.Remove(this.gameObject);
//         //         Destroy(this.gameObject);


//         //     }
//         // }



//         // void Update()
//         // {
//         // }


//         public class StateWander : State<BossPlus>
//         {


//             public StateWander(BossPlus owner) : base(owner)
//             {
//                 owner.animator.SetTrigger("Idle");
//             }

//             public override void Enter()
//             {

//             }

//             public override void Execute()
//             {

//             }

//             public override void Exit()
//             {
//             }


//         }



//         // public class StatePursuit : State<BossPlus>
//         // {

//         //     public StatePursuit(BossPlus owner) : base(owner)
//         //     {
//         //     }

//         //     public override void Enter()
//         //     {
//         //     }

//         //     public override void Execute()
//         //     {

//         //     }



//         //     public override void Exit()
//         //     {
//         //     }
//         // }

//         public class StateAttack : State<BossPlus>
//         {
           

//             public StateAttack(BossPlus owner) : base(owner)
//             {
//             }

//             public override void Enter()
//             {


//             }

//             public override void Execute()
//             {

//             }

//             public override void Exit()
//             {



//             }


//             void AttackInterval()
//             {


//             }


//             void Shoot()
//             {

//             }
//         }

//         public class StateExplode : State<BossPlus>
//         {
//             public StateExplode(BossPlus owner) : base(owner)
//             {
//             }

//             public override void Enter()
//             {

//             }


//             public override void Execute()
//             {

//             }

//             public override void Exit()
//             {
//             }
//         }
//     }
// }