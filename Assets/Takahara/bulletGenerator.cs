using UnityEngine;

public class bulletGenerator : MonoBehaviour
{
    public bulletController bull;
    public bulletController bullWall;
    public bulletController bullNext;
    public float count = 5;
    public GameObject airPlane;
    public float span = 1.0f;
    float delta = 0.0f;
    public float power;
    [SerializeField] private bulletController tmpBull;

    void Start()
    {
        airPlane = GameObject.Find("AirPlane");
        tmpBull = bull;

    }


    void Update()
    {
        CheckBullState();
        delta += Time.deltaTime;
        if (span <= delta)
        {
            Vector3 firstPosition = airPlane.transform.position;
            delta = 0;
            bulletController bullet = Instantiate(tmpBull, firstPosition, Quaternion.identity);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(airPlane.transform.forward * power);


            // bullet.airPlane = airPlane;
        }
    }

    //動作確認済み。ボタン検出によってちゃんと弾丸の変更が反映されていることが確認できた
    void CheckBullState()
    {
        air hito = airPlane.GetComponent<air>();
        if (count <= hito.point)
        {
            //Debug.Log("oke");
            tmpBull = bullNext;
        }

    }

    public void UseBulletAttack()
    {
        this.tmpBull = bull;
        Debug.Log("shine");
    }
    public void UseBulletWall()
    {
        this.tmpBull = bullWall;
        Debug.Log("unko");
    }
}