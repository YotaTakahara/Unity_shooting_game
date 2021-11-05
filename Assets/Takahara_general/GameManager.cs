using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    // Start is called before the first frame update
    [SerializeField] int maxScore = 99999;
    [SerializeField] int score;


    public int Score
    {
        set
        {
            score = Mathf.Clamp(value, 0, maxScore);
        }
        get
        {
            return score;
        }
    }

    public void Awake()
    {
        if (this != Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
