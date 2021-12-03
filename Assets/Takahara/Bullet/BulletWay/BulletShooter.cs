using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
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
        center = transform.position;
        deg = 2 * Mathf.PI / bullNum;
        bull = (GameObject)Resources.Load("EnemyBullet");
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
        // tmpSpan += Time.deltaTime;
        // if (span < tmpSpan)
        // {
        //     tmpSpan = 0;
        //     Shoot();
        // }


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
        Vector3 shotDirection = new Vector3(shot.transform.position.x - center.x, shot.transform.position.y - center.y, 0);
        rb.AddForce(shotDirection.normalized * power);

    }

    IEnumerator Shoot1()
    {
        while (true)
        {
            for (int i = 0; i < bullNum; i++)
            {
                float rad = i * deg;
                float cos = Mathf.Cos(rad);
                float sin = Mathf.Sin(rad);
                Vector3 pos = center + new Vector3(cos, sin, 0);
                InstantiateAndShoot(pos);
            }
            yield return new WaitForSeconds(span);
        }
    }
    IEnumerator Shoot2()
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
                Vector3 pos = center + new Vector3(cos, sin, 0);
                InstantiateAndShoot(pos);

            }
            yield return new WaitForSeconds(0.3f);

            count++;
        }

    }
    IEnumerator Shoot3()
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
    IEnumerator Shoot4()
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
