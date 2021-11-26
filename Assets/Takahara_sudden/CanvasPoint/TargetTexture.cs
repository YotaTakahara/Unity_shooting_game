using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ai;

public class TargetTexture : MonoBehaviour
{
    [SerializeField] private ObjectMarker _objectMarker;
    [SerializeField] private GameObject _target;
    [SerializeField] private Text text;
    private Enemy enemy;

    int check = 0;
    // Start is called before the first frame update
    void Start()
    {
        _objectMarker = GetComponent<ObjectMarker>();
        _target = _objectMarker._target;
        text = GetComponentInChildren<Text>();
        if(_target.gameObject.tag=="MonsterHP"){
             enemy = _target.GetComponent<Enemy>();
            text.text = "" + enemy.HP;
            check = 1;


        }
        else{
            text.gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(check==1){

            OnUpdateText();


        }

    }
    void OnUpdateText(){
        text.text = "" + enemy.HP;
        check = 1;

    }
}

