using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] enemyBullet;
    [SerializeField] private GameObject boss;

    public List<GameObject> attack;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        enemy = GameObject.FindGameObjectsWithTag("Monster");
         enemyBullet = GameObject.FindGameObjectsWithTag("enemyBullet");
        // enemy = GameObject.FindGameObjectsWithTag("experiment");
        attack.Add(boss);
        for (int i = 0; i < enemy.Length; i++)
        {
            attack.Add(enemy[i]);
        }

        for (int i = 0; i < enemyBullet.Length; i++)
        {
            attack.Add(enemyBullet[i]);
        }

        for (int i = 0; i < attack.Count; i++)
        {
            Debug.Log("attackContent " + attack[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("enemy+bullet " + attack.Count);
    }
}