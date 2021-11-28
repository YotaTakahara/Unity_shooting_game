using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossText : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private BossZarigani zariScript;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private Text text;
    void Start()
    {
        boss = GameObject.Find("Boss");
        zariScript = boss.GetComponent<BossZarigani>();
        scoreText = GameObject.Find("BossHP");
        text = scoreText.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        text.text = "ボスの残りHP" + zariScript.HP;


    }
}
