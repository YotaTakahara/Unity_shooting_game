using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAdder : ControllerBase
{

    int check = 1;
    float coefficient = 1;



    void Start()
    {
        Vector3 where = player.transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        // point = air.point;

        // pointAdder.check += 1;


    }

    public void PointCalcChange(float pointPlus)
    {
        //coefficient = scoreController.scoreRatio;
        AddPoint(coefficient, pointPlus);


    }
    public void AddPoint(float coefficient, float pointPlus)
    {

        point += pointPlus * coefficient;



    }
}
