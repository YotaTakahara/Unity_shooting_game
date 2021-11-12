using System.Collections.Generic;
using UnityEngine;

public class sstageGenerator : MonoBehaviour
{
    public float LaneWidth = 1.0f * 4;
    public int k = 2;
    public int stageState = 0;
    [SerializeField] private int StageChipSize = 30;

    private int currentChipIndex;
    public GameObject airPlane;
    public GameObject[] stageChips;

    public GameObject[] stageChips1;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();


    [SerializeField] private GameObject attackList;
    [SerializeField] private List list;

    void Start()
    {
        StageChipSize *= k;
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);

        attackList = GameObject.Find("attackList");
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

            //hennkou
            // Transform children = stageOb.GetComponentInChildren<Transform>();
            // Debug.Log("children " + children);

            // foreach (Transform ob in children)
            // {
            //     Debug.Log("ob " + ob);
            //     Debug.Log("ob.gameObject.tag " + ob.gameObject.tag);

            //     if (ob.gameObject.tag == "Monster")
            //     {
            //         Debug.Log("ここ呼び出されてんぞ");
            //         Debug.Log("ob.gameObject:" + ob.gameObject);
            //         // list.attack.Add(ob.gameObject);
            //     }
            // }

            generatedStageList.Add(stageOb);
        }

        while (generatedStageList.Count > preInstantiate + 2) DestroyOldestStage();
        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex)
    {
        GameObject stageObject;
        int nextStageChip;

        if (stageState == 1)
        {
            nextStageChip = Random.Range(0, stageChips1.Length);

            Debug.Log("stageStateの変更が反映された" + stageState);
            stageObject = (GameObject)Instantiate(stageChips1[nextStageChip],
                new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);
            // foreach (Transform child in stageObject.transform)
            // {
            //     if (child.gameObject.tag == "Monster")
            //     {
            //         list.attack.Add(child.gameObject);
            //     }

            // }

        }
        else
        {
            nextStageChip = Random.Range(0, stageChips.Length);

            Debug.Log("stageStateの変更が反映された" + stageState);

            //GameObjectとして消去する必要があることが分かった
            //またinstantiateとするときはprefabのものを使わないとエラーになってしまうので気をつける

            stageObject = (GameObject)Instantiate(stageChips[nextStageChip],
                new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);

            foreach (Transform childTransform in stageObject.gameObject.transform)
            {
                // Debug.Log(childTransform.gameObject.name); // 子オブジェクト名を出力
                // EnemyPoint tmp = childTransform.gameObject.GetComponent<EnemyPoint>();
                //Debug.Log("enemy:" + tmp.prefab);
            }









            // foreach (Transform child in stageObject.transform)
            // {
            //     GameObject childCha = (GameObject)child.gameObject;
            //     if (child.gameObject.tag == "Monster")
            //     {
            //         Debug.Log("child:" + child.gameObject);
            //         list.attack.Add(childCha);
            //     }

            // }

        }
        return stageObject;
    }

    void DestroyOldestStage()
    {

        //エラー解決済み
        GameObject death = (GameObject)generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(death);
    }
}