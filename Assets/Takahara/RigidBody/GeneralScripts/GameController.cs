using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject tmpStage;
    public sstageGenerator stageGenerator;
    public LifePanel panel;
    public air air;
    public GameObject airPlane;
    public Text text;
    public int stageChipSize = 0;
    public int stagePreInstantiate=0;
    [SerializeField] private int sceneNum = 0;
    [SerializeField] private int sceneDistance = 0;
    [Space]
    [SerializeField] private DesignController designController;
    [Space]
    [SerializeField] private bool check = true;
    

    void Start()
    {
        tmpStage = GameObject.Find("StageGenerator");
        stageGenerator = tmpStage.GetComponent<sstageGenerator>();
        GameObject designTmp = GameObject.Find("DesignController");
        designController = designTmp.GetComponent<DesignController>();
        airPlane = GameObject.Find("AirPlane");
        if (SceneManager.GetActiveScene().name == "Start")
        {
            PlayerPrefs.SetInt("進んだ距離", 0);
        }
        air = airPlane.GetComponent<air>();
        DontDestroyOnLoad(airPlane);
    }

    void Update()
    {
        ChangeStage();
       

        int c = CalcScore();
        int ans = air.Life();
        text.text = "Score " + c + "m" + "  倒した敵の数" + air.point + "体"+"\n"+"残存ライフ"+ans;
        panel.UpdateLife(ans);

        AirSpeedChange();

        // CheckSceneMove(c);
    }
    

    // void CheckSceneMove(int score)
    // {
    //     if (sceneNum == 1)
    //     {
    //         if (50 <= score)
    //         {
    //             SceneManager.LoadScene("Boss");
    //             sceneNum = 2;
    //         }
    //     }
    //     if (score < 400)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         Debug.Log("idooooooooooooooooooooo");
    //         int tmpScore = PlayerPrefs.GetInt("進んだ距離");

    //         PlayerPrefs.SetInt("進んだ距離", tmpScore + score);
    //         PlayerPrefs.SetInt("倒した敵の数", air.point);
    //         // airPlane.transform.position.z = 0;
    //         if (sceneNum == 0)
    //         {
    //             SceneManager.LoadScene("AI");
    //         }
    //         sceneNum = 1;
    //         airPlane.transform.position = new Vector3(0, 5, 0);


    //     }



    // }

    public void AirSpeedChange()
    {
        //動作確認済み
        int distance = (int)air.transform.position.z;
        if (400 * (this.sceneDistance + 1) < distance)
        {
            air.speedZ *= 1.1f;
            this.sceneDistance += 1;
        }

    }
    int CalcScore()
    {
        return (int)airPlane.transform.position.z;
    }


    private int checkflag = 0;
    private int checkChange = 0;
    void ChangeStage()
    {

        //動作確認済み
        //ただ改善の余地あり
        int distance = (int)air.transform.position.z;
        if (200 * (stageGenerator.stageState + 1) < distance)
        {
            Debug.Log("ステージ変更" + stageGenerator.stageState);
            stageGenerator.stageState += 1;
            checkflag = -1;
            stageGenerator.ChangeStage();
           //designController.SkyboxChange();

        }
        if (200 * (stageGenerator.stageState +1 +checkflag)+(1+stagePreInstantiate) * stageChipSize < distance)
        {
            checkflag = 0;
            designController.SkyboxChange();

        }
        // if(200<distance&&checkChange==0){
        //     checkChange = 1;
        //     designController.StageFinish();
        // }
        // Debug.Log("distance:" + distance);
        // Debug.Log("sin"+stageGenerator.stageState);
        //Debug.Log(400 * (stageGenerator.stageState + 1) + stagePreInstantiate * stageChipSize );

        // if(10<distance){
        //     Debug.Log("スカイボックス変更");
        //     designController.SkyboxChange();
        // }


    }
}