using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public LifePanel panel;
    public air air;
    public GameObject airPlane;
    public Text text;
    [SerializeField] private int sceneNum =0;

    void Start()
    {
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

        int c = CalcScore();
        int ans = air.Life();
        text.text = "Score " + c + "m" + "  倒した敵の数" + air.point + "体";
        panel.UpdateLife(ans);

        CheckSceneMove(c);
    }

    void CheckSceneMove(int score)
    {
        if(sceneNum==1){
            if(50<=score){
                SceneManager.LoadScene("Boss");
                sceneNum =2;
            }
        }
        if (score < 400)
        {
            return;
        }
        else
        {
            Debug.Log("idooooooooooooooooooooo");
            int tmpScore = PlayerPrefs.GetInt("進んだ距離");

            PlayerPrefs.SetInt("進んだ距離", tmpScore + score);
            PlayerPrefs.SetInt("倒した敵の数", air.point);
            // airPlane.transform.position.z = 0;
            if (sceneNum == 0)
            {
                SceneManager.LoadScene("AI");
            }
            sceneNum = 1;
            airPlane.transform.position = new Vector3(0, 5, 0);


        }



    }
    int CalcScore()
    {
        return (int)airPlane.transform.position.z;
    }
}