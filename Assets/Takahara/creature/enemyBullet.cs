using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public GameObject bullet;
    public float span = 1.5f;
    private float timing = 0;
    private float a = 0;
    public float Speed = 23.0f;


    void Update()
    {
        a += Time.deltaTime;
        timing += Time.deltaTime;
        if (span < timing)
        {
            timing = 0;
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 where = transform.position + new Vector3(0, 8, 0);
        GameObject shin = Instantiate(bullet, where, Quaternion.identity);

        Rigidbody attack = shin.GetComponent<Rigidbody>();
        Vector3 direction = transform.forward + new Vector3(0, 0f, 0);
        //Debug.Log(direction);
        attack.AddForce(direction * Speed);
    }
}