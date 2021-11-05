using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float percentage;
    [SerializeField] private LifeGauge slider;
    void Start()
    {
        percentage = 100;


    }

    // Update is called once per frame
    void Update()
    {

    }
    void Damage(float damage)
    {
        //  LifeGauge.value -= damage / percentage;

    }
}
