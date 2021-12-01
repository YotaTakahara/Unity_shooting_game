using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    public float LaneWidth = 1.0f * 4;
    public int k = 2;
    public int stageState = 0;
    public int StageChipSize = 30;

    private int currentChipIndex;
    public GameObject airPlane;
    [SerializeField] private GameObject[] stageChips0;

    [SerializeField] private GameObject[] stageChips1;
    [SerializeField] private GameObject[] stageChips2;
    [SerializeField] private GameObject[] stageChangeStage;

    [SerializeField] private GameObject[] currentStageChips;
    [SerializeField] private StageList stageList;

    public int currentStageIndex = 0;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();


    [SerializeField] private GameObject attackList;
    [SerializeField] private List list;
    [SerializeField] private GameController gameController;

    void Start()
    {
        GameObject conTmp = GameObject.Find("GameController");
        gameController = conTmp.GetComponent<GameController>();
        GameObject stageTmp = GameObject.Find("StageList");
        stageList = stageTmp.GetComponent<StageList>();
        int stageNum = stageList.stageNum;
        for (int i = 0; i < stageNum; i++)
        {
            if (i == 0)
            {
                stageChips0 = stageList.stageChips0;
            }
            else if (i == 1)
            {
                stageChips1 = stageList.stageChips1;
            }
            else if (i == 2)
            {
                stageChips2 = stageList.stageChips2;
            }

        }
        stageChangeStage = stageList.stageChangeStage;
        currentStageChips = stageChips2;
        //ここでちょびっと変更している



        StageChipSize *= k;
        gameController.stageChipSize = StageChipSize;
        gameController.stagePreInstantiate = preInstantiate;

        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);

        attackList = GameObject.Find("AttackList");
        list = attackList.GetComponent<List>();
    }


    void Update()
    {
        int charaIndex = (int)airPlane.transform.position.z / StageChipSize;
        if (charaIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaIndex + preInstantiate);
        }
    }

    //エラー
    //なんでバグってるのかわからん



    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageOb = GenerateStage(i);

            generatedStageList.Add(stageOb);
        }

        while (generatedStageList.Count > preInstantiate + 1) DestroyOldestStage();
        currentChipIndex = toChipIndex;
    }
    public void UpdateStageChange(int which)
    {

        GameObject stageOb = GenerateStageChange(which);
        generatedStageList.Add(stageOb);
        //while (generatedStageList.Count > preInstantiate + 1) DestroyOldestStage();
        currentChipIndex += 1;


    }

    GameObject GenerateStage(int chipIndex)
    {
        GameObject stageObject;
        int nextStageChip;
        nextStageChip = Random.Range(0, currentStageChips.Length);

        Debug.Log("stageStateの変更が反映された" + stageState);
        stageObject = (GameObject)Instantiate(currentStageChips[nextStageChip],
            new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);
        return stageObject;
    }
    GameObject GenerateStageChange(int nextStageChip)
    {
        GameObject stageObject = (GameObject)Instantiate(stageChangeStage[nextStageChip],
        new Vector3(0, 0, (currentChipIndex + 1) * StageChipSize), Quaternion.identity);
        return stageObject;

    }

    void DestroyOldestStage()
    {

        //エラー解決済み
        GameObject death = (GameObject)generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(death);
    }
    public void ChangeStage()
    {
        int now = stageState;
        UpdateStageChange(now - 1);
        if (now == 0)
        {
            currentStageChips = stageChips0;
        }
        else if (now == 1)
        {
            currentStageChips = stageChips1;
        }
        else if (now == 2)
        {
            currentStageChips = stageChips2;
        }

    }
}