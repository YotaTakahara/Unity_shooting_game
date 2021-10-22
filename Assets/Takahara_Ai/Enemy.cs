using UnityEngine;

namespace Ai
{
    public enum EnemyState
    {
        wander,
        pursuit,
        attack,
        explode,
    }

    public class StateMachineEnemy : StateMachine<Enemy>
    {
    }

    public class Enemy : StatefulObjectBase<Enemy, EnemyState>
    {
        // private int maxLife = 3;
        // private int life;
        //
        // private float speed = 10f;
        // private float rotationSmooth = 1f;
        // private float turretRotationSmooth = 0.8f;
        // private float attackInterval = 2f;
        //
        // private float pursuitSqrDistance = 2500f;
        // private float attackSqrDistance = 900f;
        // private float margin = 50f;
        //
        // private float changeTargetSqrDistance = 40f;

        //疑問：一緒にMonoBehaviourを継承できない 
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject explode;
        [SerializeField] private GameObject player;
        [SerializeField] public float speed = 2.0f;


        void Start()
        {
            player = GameObject.Find("AirPlane");
            //  bullet = GameObject.FindGameObjectWithTag("enemyBullet");
            //Debug.Log("player " + player);


            Initialize();
        }

        public void Initialize()
        {
            StateWander stateWander = this.gameObject.AddComponent<StateWander>();
            stateWander.owner = this;

            //Debug.Log("airplane really find??" + stateWander.owner);
            StatePursuit statePursuit = this.gameObject.AddComponent<StatePursuit>();
            statePursuit.owner = this;
            StateAttack stateAttack = this.gameObject.AddComponent<StateAttack>();
            stateAttack.owner = this;
            StateExplode stateExplode = this.gameObject.AddComponent<StateExplode>();
            stateExplode.owner = this;
            //Debug.Log("stateWander" + stateWander.owner);


            stageList.Add(stateWander);
            stageList.Add(statePursuit);
            stageList.Add(stateAttack);
            stageList.Add(stateExplode);
            // Debug.Log("stageList " + stageList);
            stateMachine = this.gameObject.AddComponent<StateMachineEnemy>();


            EnemyState first = EnemyState.wander;
            //stateMachine = new StateMachine<Enemy>();
            // Debug.Log("stateMachine" + stateMachine);
            // Debug.Log("first" + first);
            ChangeStateNext((int) first);
        }

        public void TakeDamage()
        {
        }


        // void Update()
        // {
        // }


        public class StateWander : State<Enemy>
        {
            [SerializeField] private Vector3 targetPosition;

            [SerializeField] private float distance;
            [SerializeField] private float roadLength;


            public StateWander(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
                targetPosition = RandomPosition();
            }

            public override void Execute()
            {
                distance = 100f;
                roadLength = 40f;
                //Debug.Log("roadLength " + roadLength);
                // Debug.Log("owner" + owner);
                // Debug.Log("player hikouki" + owner.player);
                float diff = Vector3.Magnitude(owner.player.transform.position - owner.transform.position);
                //Debug.Log("diff " + diff);
                //Debug.Log("distance " + distance);
                if (diff < distance)
                {
                    int index = (int) EnemyState.pursuit;
                    owner.ChangeStateNext(index);
                    Debug.Log("wander to pursuit");
                    //   stateMachine.ChangeState();
                }

                float distanceGoal = Vector3.Magnitude(targetPosition - owner.transform.position);
                if (distanceGoal < roadLength)
                {
                    targetPosition = RandomPosition();
                }

                Quaternion targetRotation = Quaternion.LookRotation(targetPosition - owner.transform.position);
                owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime);
                owner.transform.Translate(Vector3.forward * owner.speed * Time.deltaTime);
            }

            public override void Exit()
            {
            }

            public Vector3 RandomPosition()
            {
                float size = 100f;
                return new Vector3(Random.Range(-size, size), 0, Random.Range(-size, size));
            }
        }

        public class StatePursuit : State<Enemy>
        {
            [SerializeField] private Vector3 wherePlayer;
            [SerializeField] private float stopCircle;

            public StatePursuit(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
            }

            public override void Execute()
            {
                wherePlayer = owner.player.transform.position;
                stopCircle = 25f;

                Debug.Log("Excute pursuit");
                float diff = Vector3.Magnitude(wherePlayer - owner.transform.position);
                Debug.Log("diff " + diff);


                if (diff <= stopCircle)
                {
                    int index = (int) EnemyState.attack;
                    owner.ChangeStateNext(index);
                }
                else
                {
                    Quaternion targetRotation = Quaternion.LookRotation(wherePlayer - owner.transform.position);
                    owner.transform.rotation =
                        Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime);
                    owner.transform.Translate(Vector3.forward * owner.speed * 2 * Time.deltaTime);
                }
            }

            public override void Exit()
            {
            }
        }

        public class StateAttack : State<Enemy>
        {
            //  [SerializeField] GameObject bullet;
            public float Speed;
            public GameObject attackList;
            public float timing = 0f;
            public float bombTime = 0f;
            [SerializeField] private float stopCircle;
            [SerializeField] private Vector3 wherePlayer;
            [SerializeField] private float span;


            public StateAttack(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
            }

            public override void Execute()
            {
                attackList = GameObject.Find("attackList");
                wherePlayer = owner.player.transform.position;
                stopCircle = 25f;

                Debug.Log("Excute pursuit");
                float diff = Vector3.Magnitude(wherePlayer - owner.transform.position);

                if (stopCircle < diff)
                {
                    int index = (int) EnemyState.pursuit;
                    owner.ChangeStateNext(index);
                }


                Debug.Log("attackState");
                Quaternion targetRotation = Quaternion.LookRotation(wherePlayer - owner.transform.position);
                owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime);
                span = 1.5f;


                this.timing += Time.deltaTime;
                this.bombTime += Time.deltaTime;
                Debug.Log("timing " + timing);
                if (span < timing)
                {
                    timing = 0;
                    Shoot();
                }

                if (5.0f < bombTime)
                {
                    int index = (int) EnemyState.explode;
                    owner.ChangeStateNext(index);
                }
            }

            public override void Exit()
            {
            }


            void Shoot()
            {
                //これが適用されるのは盤面上に存在しているもののみ
                Speed = 560f;
                Vector3 where = transform.position + new Vector3(0, 8, 0);

                GameObject shin = Instantiate(owner.bullet, where, Quaternion.identity);
                List eneNum = attackList.GetComponent<List>();
                eneNum.attack.Add(shin);

                Rigidbody attack = shin.GetComponent<Rigidbody>();
                Vector3 direction = transform.forward + new Vector3(0, 0f, 0);
                //Debug.Log(direction);
                attack.AddForce(direction * Speed);
            }
        }

        public class StateExplode : State<Enemy>
        {
            public StateExplode(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
                Debug.Log("destroy this monster in 1.0 second");
                GameObject shin = Instantiate(owner.explode, transform.position, Quaternion.identity);
                Destroy(owner.gameObject, 1.0f);
            }

            public override void Execute()
            {
            }

            public override void Exit()
            {
            }
        }
    }
}