using System.Collections.Generic;
using UnityEngine;

public class sstageGenerator : MonoBehaviour
{
    public int k = 2;
    public int stageState = 0;
    [SerializeField]private  int StageChipSize = 30;
    private int currentChipIndex;
    public GameObject airPlane;
    public GameObject[] stageChips;

    public GameObject[] stageChips1;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();


    void Start()
    {
        StageChipSize *= k;
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }


    void Update()
    {
        int charaIndex = (int) airPlane.transform.position.z / StageChipSize;
        if (charaIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
        {
            GameObject stageOb = GenerateStage(i);
            generatedStageList.Add(stageOb);
        }

        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);
        GameObject stageObject ;
        if (stageState == 1)
        {
            stageObject = Instantiate(stageChips1[nextStageChip],
                new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);
        }else{
            stageObject = Instantiate(stageChips[nextStageChip],
                new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);

        }
        return stageObject;
    }

    void DestroyOldestStage()
    {
        GameObject death = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(death);
    }
}