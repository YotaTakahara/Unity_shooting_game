using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private GameObject[] enemyHP;
    [SerializeField] private GameObject[] enemyBullet;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject[] wall;

    public List<GameObject> attack;

    //動作確認済み
    public List<GameObject> obstacle;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        enemy = GameObject.FindGameObjectsWithTag("Monster");
        enemyHP = GameObject.FindGameObjectsWithTag("MonsterHP");
        enemyBullet = GameObject.FindGameObjectsWithTag("enemyBullet");
        wall = GameObject.FindGameObjectsWithTag("Wall");

        // enemy = GameObject.FindGameObjectsWithTag("experiment");
        attack.Add(boss);
        for (int i = 0; i < enemy.Length; i++)
        {
            attack.Add(enemy[i]);
        }
        for (int i = 0; i < enemyHP.Length; i++)
        {
            attack.Add(enemyHP[i]);
        }


        for (int i = 0; i < enemyBullet.Length; i++)
        {
            attack.Add(enemyBullet[i]);
        }

        for (int i = 0; i < attack.Count; i++)
        {
            //            Debug.Log("attackContent " + attack[i]);
        }
        for (int i = 0; i < wall.Length; i++)
        {

            obstacle.Add(wall[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}