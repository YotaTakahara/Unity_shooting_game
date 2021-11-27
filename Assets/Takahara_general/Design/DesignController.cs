using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Material> skybox = new List<Material>();
    [SerializeField] float span = 5.0f;
    [SerializeField] float tmpSpan = 0;
    [SerializeField] GameController gameController;
    [SerializeField] private sstageGenerator stageGenerator;
    [SerializeField]int tmp = 0;
    void Start()
    {
        GameObject gameTmp = GameObject.Find("GameController");
        gameController = gameTmp.GetComponent<GameController>();
        GameObject stageTmp = GameObject.Find("StageGenerator");
        stageGenerator = stageTmp.GetComponent<sstageGenerator>();
                //RenderSettings.skybox = skybox[0];

    }

    // Update is called once per frame
    void Update()
    {
        //tmpSpan += Time.deltaTime;
        // if(span<tmpSpan){
        //     tmpSpan = 0;
           
        //     RenderSettings.skybox = skybox[tmp];
        //     tmp += 1;
        // }

    }
    public void SkyboxChange(){
        tmp += 1;
        RenderSettings.skybox = skybox[tmp];
        



    }
    public void StageFinish(){
        stageGenerator.UpdateStageChange(0);
    }
}
