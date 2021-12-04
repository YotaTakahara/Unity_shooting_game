using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoreChange;
    public float scoreRatio;
    [SerializeField] string lastEnemy = null;
    [SerializeField] GameObject last = null;
    [SerializeField] private Text text;
    int kuso = 0;
    bool checkFlag = true;

    void Start()
    {
        GameObject textTmp = GameObject.Find("RatioScore");
        text = textTmp.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "scoreChange:" + scoreChange + "\n" + "scoreRatio:" + scoreRatio;
        ratioCalc();
    }
    public void RatioChange(GameObject tmp)
    {
        string tmpName = tmp.name;
        //        Debug.Log("last:" + last.name);
        Debug.Log("tmpName:" + tmpName);
        Debug.Log("lastEnemy:" + lastEnemy);
        if (lastEnemy != null)
        {


            if (lastEnemy == tmpName)
            {
                kuso += 1;
                if (kuso == 2)
                {
                    Debug.Log("last:" + lastEnemy);
                    Debug.Log("tmp:" + tmp);

                    scoreChange += 1;
                    checkFlag = true;
                    kuso = 0;

                }

            }
            else
            {
                kuso = 0;
                scoreChange = 0;
                scoreRatio = 1;
                lastEnemy = tmp.name;

            }
        }
        else
        {
            lastEnemy = tmpName;
        }

        // last = tmp;



    }
    public void ratioCalc()
    {
        if(1<=scoreChange&&checkFlag==true){
            scoreRatio = 1.0f + 1.0f * scoreChange / 10;
            checkFlag = false;
            StartCoroutine(TextDisplay());




        }
        scoreRatio = 1.0f + 1.0f * scoreChange / 5;
     //   StartCoroutine(TextDisplay());




       

    }
    IEnumerator TextDisplay(){
        text.text = "scoreChange:" + scoreChange + "\n" + "scoreRatio:" + scoreRatio;
      // text.text += "";
        text.fontSize = 48;
        text.color = Color.red;
        yield return new WaitForSeconds(5.0f);
        text.text = "scoreChange:" + scoreChange + "\n" + "scoreRatio:" + scoreRatio;
       
        text.fontSize = 32;
        text.color = Color.blue;
       // checkFlag = true;


    }
    

    
}
