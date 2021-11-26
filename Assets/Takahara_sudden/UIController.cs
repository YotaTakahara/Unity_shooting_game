using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private RectTransform _markerPanel;
    [SerializeField] private ObjectMarker _markerPrefab;
   // [SerializeField] private EnemyPoint enemyPoint;


    public void UIInstance(Transform target){
        var marker = Instantiate(_markerPrefab, _markerPanel);
        marker.Initialize(target);

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
