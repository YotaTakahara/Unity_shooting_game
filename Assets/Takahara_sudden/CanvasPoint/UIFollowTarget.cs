using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Graphic))]
public class UIFollowTarget : MonoBehaviour
{
    RectTransform rectTransform = null;
    public Transform target = null;
    [SerializeField] Canvas canvas;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponent<Graphic>().canvas;
    }
    void Update()
    {
        var pos = Vector2.zero;
        var uiCamera = Camera.main;
        var worldCamera = Camera.main;
        var canvasRect = canvas.GetComponent<RectTransform>();

        var screenPos = RectTransformUtility.WorldToScreenPoint(worldCamera, target.position);
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCamera, out pos);
        rectTransform.localPosition = pos;
    }


}
