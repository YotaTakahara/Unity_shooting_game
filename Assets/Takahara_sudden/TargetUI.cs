using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetUI : MonoBehaviour
{
    RectTransform rectTransform;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);

    }
}
