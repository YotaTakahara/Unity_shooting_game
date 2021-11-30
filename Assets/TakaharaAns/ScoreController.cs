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
        Debug.Log("last:" + last.name);
        Debug.Log("tmp:" + tmp.name);
        if (last != null)
        {

            if (last.name == tmpName)
            {
                scoreChange += 1;
            }
            else
            {
                scoreChange = 0;
                // lastEnemy = tmp.name;

            }
        }

        last = tmp;


    }
    public void ratioCalc(){
        scoreRatio = 1.0f + 1.0f*scoreChange / 5;
        Debug.Log("scoreRatio:" + scoreRatio);
    }
}
