using UnityEngine;

public enum EnemyState
{
    wander,
    pursuit,
    attack,
    explode,
}

public class Enemy : StatefulObjectBase<Enemy, EnemyState>
{
    //疑問：一緒にMonoBehaviourを継承できない 
    [SerializeField] private GameObject player;
    [SerializeField] public float speed;


    void Start()
    {
        player = GameObject.Find("airPlane");


        Initialize();
    }

    public void Initialize()
    {
        stageList.Add(new StateWander(this));
        stageList.Add(new StatePursuit(this));
        stageList.Add(new StateAttack(this));
        stageList.Add(new StateExplode(this));
        stateMachine = new StateMachine<Enemy>();
        //stateMachine = GameObject.AddComponent<Enemy>();
        EnemyState first = EnemyState.wander;
        stateMachine = new StateMachine<Enemy>();
        ChangeStateNext((int) first);
    }


    void Update()
    {
    }


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
            float diff = Vector3.Magnitude(owner.player.transform.position - owner.transform.position);
            if (diff < distance)
            {
                int index = (int) EnemyState.pursuit;
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
        public StatePursuit(Enemy owner) : base(owner)
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