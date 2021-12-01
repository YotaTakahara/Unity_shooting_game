using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private GameObject bull;
    [SerializeField] private Vector3 center;
    [SerializeField] private float radius;
    public float span = 2.0f;
    public int power = 500;
    public int bullNum;
    float deg;
    float tmpSpan = 0;
    List<GameObject> bullList = new List<GameObject>();

    void Start()
    {
        center = transform.position;
        deg = 2 * Mathf.PI / bullNum;
        bull = (GameObject)Resources.Load("EnemyBullet");

    }

    // Update is called once per frame
    void Update()
    {
        tmpSpan += Time.deltaTime;
        if (span < tmpSpan)
        {
            tmpSpan = 0;
            Shoot();
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
