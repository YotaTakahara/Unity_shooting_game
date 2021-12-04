using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBulletController:bulletController{


     private void Start() {
        enemyList.Add(this.gameObject);

    }

}