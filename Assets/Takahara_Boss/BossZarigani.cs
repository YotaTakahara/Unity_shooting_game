using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Ai;

public enum BossState
{
    idle,
    attack,
    damage,
    dead,

}
public abstract class Zari : StatefulObjectBase<BossZarigani, BossState>
{

}
public class StateMachineBoss : StateMachine<BossZarigani>
{
}

public class BossZarigani : Zari
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private air airScript;
    [SerializeField] public float distance;
    [SerializeField] public float span;
    [SerializeField] public float HP;
    //hennkou
    [SerializeField] private int stabDamage;
    [SerializeField] private int smashDamage;
    //hennkou

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("AirPlane");
        HP = 100f;
        distance = 100f;
        span = 10f;
        airScript = player.GetComponent<air>();
        speed = airScript.speed;
        //hennkou
        stabDamage = 5;
        smashDamage = 10;
        //hennkou
        Initialize();
    }
    void Initialize()
    {
        ZariIdle idle = this.gameObject.AddComponent<ZariIdle>();
        idle.owner = this;
        ZariAttack attack = this.gameObject.AddComponent<ZariAttack>();
        attack.owner = this;
        ZariDamage damage = this.gameObject.AddComponent<ZariDamage>();
        damage.owner = this;
        ZariDead dead = this.gameObject.AddComponent<ZariDead>();
        dead.owner = this;

        stateList.Add(idle);
        stateList.Add(attack);
        stateList.Add(damage);
        stateList.Add(dead);
        stateMachine = this.gameObject.AddComponent<StateMachineBoss>();
        int first = (int)BossState.idle;
        ChangeStateNext(first);


    }

    public override void FixedUpdate()
    {
        transform.Translate(0, 0, -speed);
        stateMachine.FixedUpdate();
        if(this.HP<=0){
            int index=(int)BossState.dead;
            ChangeStateNext(index);

        }
    }

    public class ZariIdle : State<BossZarigani>
    {
        [SerializeField] private float speed;
        public ZariIdle(BossZarigani owner) : base(owner) { }
        public override void Enter()
        {
            this.speed = owner.speed;
        }
        public override void Execute()
        {
            // this.speed = owner.speed;
            // Vector3 move = new Vector3(0, 0, speed);
            // owner.transform.Translate(move);
            owner.animator.SetTrigger("Walk Backward");

            float diff = Vector3.Magnitude(owner.transform.position - owner.player.transform.position);
            if (diff < owner.distance)
            {
                int index = (int)BossState.attack;
                owner.ChangeStateNext(index);
            }

        }
        public override void Exit() { }
    }
    public class ZariAttack : State<BossZarigani>
    {

        public float span;
        public float speed;
        public float tmpSpan;
        public float HP;
        public ZariAttack(BossZarigani owner) : base(owner)
        {

        }
        public override void Enter()
        {
            this.span = owner.span;
            this.HP = owner.HP;
            tmpSpan = 0f;
        }
        public override void Execute()
        {
            // this.speed = owner.speed;
            // Vector3 move = new Vector3(0, 0, speed);
            // owner.transform.Translate(move);
            if (Input.GetAxis("Vertical") != 0)
            {
                Debug.Log("response");
                int index = (int)BossState.damage;
                owner.ChangeStateNext(index);

            }

            this.HP = owner.HP;
            Debug.Log("HP " + this.HP);
            tmpSpan += Time.fixedDeltaTime;
            if (0 < HP && HP < 20)
            {

                owner.animator.SetTrigger("Run Backward");

                span = 7.0f;
                if (span < tmpSpan)
                {
                    SmashAttack();
                    tmpSpan = 0f;

                }



            }
            else if (HP < 20 && HP < 80)
            {
                owner.animator.SetTrigger("Walk Backward In Place");
                span = 7.0f;
                Debug.Log("span " + span);
                if (span < tmpSpan)
                {

                    SmashAttack();
                    tmpSpan = 0f;

                }
            }
            else
            {
               // Debug.Log("じかんはおかしくない");

                if (span < tmpSpan)
                {
                    Debug.Log("okei");
                    owner.animator.SetTrigger("Walk Backward In Place");

                    StabAttack();
                    tmpSpan = 0f;


                }
                else
                {
                    //  owner.animator.SetTrigger("Walk Backward");
                }
            }


        }



        //hennkou
        public void StabAttack()
        {
            Debug.Log("attack");
            owner.animator.SetTrigger("Stab Attack");
            owner.airScript.AccidentBossDamage(owner.stabDamage);
            Debug.Log("player hp " + owner.airScript.hp);
        }
        public void SmashAttack()
        {
            owner.animator.SetTrigger("Smash Attack");
            owner.airScript.AccidentBossDamage(owner.smashDamage);
            Debug.Log("player hp " + owner.airScript.hp);
        }
        //hennkou
    }
    public class ZariDamage : State<BossZarigani>
    {

        public ZariDamage(BossZarigani owner) : base(owner) { }
        public override void Enter()
        {
            owner.animator.SetTrigger("Take Damage");
            owner.HP -= 10;
            Debug.Log("ダメージを喰らい、ボスのHPは　" + owner.HP);
            Debug.Log("damage");
        }
        public override void Execute()
        {
            int index = (int)BossState.idle;
            owner.ChangeStateNext(index);
        }
    }
    public class ZariDead : State<BossZarigani> {
        public ZariDead(BossZarigani owner) : base(owner) { } 
        public override void Enter(){
            owner.animator.SetTrigger("Die");;

        }
        public override void Execute(){}
        public override void Exit(){}
    }



}
