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
    public　class StateMachineEnemy:StateMachine<Enemy>{

    }

    public class Enemy : StatefulObjectBase<Enemy, EnemyState>
    {
        //疑問：一緒にMonoBehaviourを継承できない 
        [SerializeField] private GameObject player;
        [SerializeField] public float speed=2.0f;


        void Start()
        {
            player = GameObject.Find("airPlane");
            Debug.Log("player " + player);


            Initialize();
        }

        public void Initialize()
        {

            StateWander stateWander = this.gameObject.AddComponent<StateWander>() ;
            stateWander.owner = this;

            Debug.Log("airplane really find??" + stateWander.owner);
            StatePursuit statePursuit = this.gameObject.AddComponent<StatePursuit>();
            statePursuit.owner = this;
            StateAttack stateAttack = this.gameObject.AddComponent<StateAttack>();
            stateAttack.owner = this;
            StateExplode stateExplode = this.gameObject.AddComponent<StateExplode>();
            stateExplode.owner = this;
            Debug.Log("stateWander" + stateWander.owner);




            stageList.Add(stateWander);
            stageList.Add(statePursuit);
            stageList.Add(stateAttack);
            stageList.Add(stateExplode);
            Debug.Log("stageList " + stageList);
            stateMachine = this.gameObject.AddComponent<StateMachineEnemy>();


            EnemyState first = EnemyState.wander;
            //stateMachine = new StateMachine<Enemy>();
            Debug.Log("stateMachine"+stateMachine);
            Debug.Log("first" + first);
            ChangeStateNext((int)first);
        }


        // void Update()
        // {
        // }


        public class StateWander : State<Enemy>
        {
            [SerializeField] private Vector3 targetPosition;
            public float distance = 20f;
            public float roadLength = 20f;

            public StateWander(Enemy owner) : base(owner)
            {
             
            }

            public override void Enter()
            {
                targetPosition = RandomPosition();
            }

            public override void Execute()
            {
                Debug.Log("owner" + owner);
                Debug.Log("player hikouki" + owner.player);
                float diff = Vector3.Magnitude(owner.player.transform.position - owner.transform.position);
                if (diff < distance)
                {
                    int index = (int)EnemyState.pursuit;
                    owner.ChangeStateNext(index);
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
                wherePlayer = owner.player.transform.position;
            }

            public override void Execute()
            {
                float diff = Vector3.Magnitude(wherePlayer - owner.transform.position);

                if (diff <= stopCircle)
                {
                    int index = (int)EnemyState.attack;
                    owner.ChangeStateNext(index);


                }
                else
                {
                    Quaternion targetRotation = Quaternion.LookRotation(wherePlayer - owner.transform.position);
                    owner.transform.rotation = Quaternion.Slerp(owner.transform.rotation, targetRotation, Time.deltaTime);
                    owner.transform.Translate(Vector3.forward * owner.speed * 2 * Time.deltaTime);
                }
            }

            public override void Exit()
            {
            }
        }

        public class StateAttack : State<Enemy>
        {
            public StateAttack(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
            }

            public override void Execute()
            {
            }

            public override void Exit()
            {
            }
        }

        public class StateExplode : State<Enemy>
        {
            public StateExplode(Enemy owner) : base(owner)
            {
            }

            public override void Enter()
            {
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