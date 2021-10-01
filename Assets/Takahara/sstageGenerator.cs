using System.Collections.Generic;
using UnityEngine;

public class sstageGenerator : MonoBehaviour
{
    private const int StageChipSize = 250;
    private int currentChipIndex;
    public GameObject airPlane;
    public GameObject[] stageChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();


    void Start()
    {
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
        GameObject stageObject = Instantiate(stageChips[nextStageChip],
            new Vector3(-250, -3, chipIndex * StageChipSize), Quaternion.identity);
        return stageObject;
    }

    void DestroyOldestStage()
    {
        GameObject death = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(death);
    }
}