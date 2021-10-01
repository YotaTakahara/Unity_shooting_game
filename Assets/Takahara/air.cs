using UnityEngine;

public class Air : MonoBehaviour
{
    private float m_MiuTurnInputValue;

    [SerializeField] private float m_Speed;

    private float Speed
    {
        get => m_Speed;
        set => m_Speed = value;
    }

    private class SomeClass
    {
        private int m_Some;
    }

    private SomeClass m_SomeClass;


    /// <summary>
    /// スタンしているか？
    /// </summary>
    private bool IsStun() => false;
}

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
    }

    void Update()
    {
        if (IsStun())
        {
            miuRb.velocity = Vector3.zero;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            // 前進は自動
            transform.Translate(0f, 0f, speed);

            // 旋回
            miuTurnInputValue = Input.GetAxis("Horizontal");
            float turn = miuTurnInputValue * 100 * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
            miuRb.MoveRotation(miuRb.rotation * turnRotation);

            // 機首（上昇、下降）
            miuNoseInputValue = Input.GetAxis("Vertical");
            float noseTurn = miuNoseInputValue * 30 * Time.deltaTime;
            Quaternion turnNoseRotation = Quaternion.Euler(noseTurn, 0, 0);
            miuRb.MoveRotation(miuRb.rotation * turnNoseRotation);
            //   Debug.Log("speed:" + miuRb.velocity);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (IsStun()) return;
        life--;
        recoverTime = stopTime;
        Debug.Log(life);
        Instantiate(fire, transform.position, Quaternion.identity);
        Destroy(other.gameObject);
    }
}