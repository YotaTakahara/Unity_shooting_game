using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerBase : MonoBehaviour
{
    public GameObject player;
    public air air;
    public GameController gameController;
    public StageGenerator stageGenerator;
    public GameObject attackList;
    public List list;
    public StageList stageList;
    public DesignController designController;
    public UIController uiController;
    public ScoreController scoreController;
    public PointAdder pointAdder;
    [Space]
    public float point = 0;

    void Awake()
    {
        player = GameObject.Find("AirPlane");
        air = player.GetComponent<air>();
        GameObject conTmp = GameObject.Find("GameController");
        gameController = conTmp.GetComponent<GameController>();
        GameObject stageTmp = GameObject.Find("StageGenerator");
        stageGenerator = stageTmp.GetComponent<StageGenerator>();
        attackList = GameObject.Find("AttackList");
        list = attackList.GetComponent<List>();
        GameObject stageListTmp = GameObject.Find("StageList");
        stageList = stageListTmp.GetComponent<StageList>();
        GameObject designTmp = GameObject.Find("DesignController");
        designController = designTmp.GetComponent<DesignController>();
        GameObject scoreTmp = GameObject.Find("ScoreController");
        scoreController = scoreTmp.GetComponent<ScoreController>();
        GameObject adderTmp = GameObject.Find("PointAdder");
        pointAdder = adderTmp.GetComponent<PointAdder>();
        GameObject uiTmp = GameObject.Find("UIController");
        uiController = uiTmp.GetComponent<UIController>();



    }


    // Update is called once per frame

}
