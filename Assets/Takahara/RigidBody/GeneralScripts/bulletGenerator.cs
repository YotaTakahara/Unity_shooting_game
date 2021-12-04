using UnityEngine;

public class bulletGenerator : MonoBehaviour
{
    [SerializeField] private List list;
    public GameObject bull;
    public GameObject bullWall;
    public GameObject bullNext;
    public float count = 5;
    public GameObject player;
    public float span = 1.0f;
    float delta = 0.0f;
    public float power;
    [SerializeField] private GameObject tmpBull;
    //下の文字を用いて銃弾変更に対応させている
    //銃弾変更語対応できないようにしてしまったのでそこをフラグによって変更できるようにした
    float bullChan = 0;


    void Start()
    {
        player = GameObject.Find("AirPlane");
        tmpBull = bull;
        // GameObject listTmp = GameObject.Find("AttackList");
        // list = listTmp.GetComponent<List>();



    }


    void Update()
    {
        CheckBullState();
        delta += Time.deltaTime;
        if (span <= delta)
        {
            Vector3 firstPosition = player.transform.position;
            delta = 0;
            GameObject bullet = (GameObject)Instantiate(tmpBull, firstPosition, Quaternion.identity);
            //list.attack.Add(bullet);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(player.transform.forward * power);


            // bullet.player = player;
        }
    }

    //動作確認済み。ボタン検出によってちゃんと弾丸の変更が反映されていることが確認できた
    void CheckBullState()
    {
        air hito = player.GetComponent<air>();
        if (count <= hito.point && bullChan == 0)
        {
            //Debug.Log("oke");
            tmpBull = bullNext;
        }

    }

    public void UseBulletAttack()
    {
        bullChan = 0;
        this.tmpBull = bull;
        Debug.Log("shine");
    }
    public void UseBulletWall()
    {
        bullChan = 1;
        this.tmpBull = bullWall;
        Debug.Log("unko");
    }
}