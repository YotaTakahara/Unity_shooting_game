using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoreChange;
    public float scoreRatio;
    [SerializeField] string lastEnemy=null;
    [SerializeField] GameObject last=null;
    [SerializeField] private Text text;
    int kuso = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text ="scoreChange"+scoreChange+"\n"+ "scoreRatio" + scoreRatio;
        ratioCalc();
    }
    public void RatioChange(GameObject tmp){
        string tmpName = tmp.name;
//        Debug.Log("last:" + last.name);
        Debug.Log("tmp:" + tmp.name);
        if (lastEnemy != null)
        {
            

            if (lastEnemy == tmpName)
            {kuso += 1;
                if(kuso==2){
                    Debug.Log("last:" + last);
                    Debug.Log("tmp:" + tmp);

                    scoreChange += 1;
                    kuso = 0;

                }
               
            }
            else
            {
                scoreChange = 0;
                scoreRatio = 1;
                lastEnemy = tmp.name;

            }
        }else{
            lastEnemy = tmpName;
        }

       // last = tmp;
       


    }
    public void ratioCalc(){
        if (5 <= scoreChange)
        {
            scoreRatio = 1.0f + 1.0f * scoreChange / 5;
            //        Debug.Log("scoreRatio:" + scoreRatio);
        }
    }
}
