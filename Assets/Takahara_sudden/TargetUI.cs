using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    RectTransform rectTransform;
    public Transform target=null;
    public Vector3 targetPosition;
    private int check=0;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        if(target==null){
            check= 1;
            }

    }

    // Update is called once per frame
    void Update()
    {
        if(check==0){
            rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);

        }else{
            rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetPosition);
        }
        

    }
}
