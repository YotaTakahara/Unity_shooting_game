using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBulletGenerator : MonoBehaviour
{
    [SerializeField] GameObject boss;
    [SerializeField] float radius;
    [SerializeField] float[] xRange=new float[2];
    [SerializeField] float[] yRange=new float[2];
    [SerializeField] float zRange;
    [SerializeField] private GameObject bull;

    [SerializeField] private GameObject targetImage;
    [SerializeField] private GameObject canvas;
    [SerializeField] int bullNum;
    [SerializeField] Rigidbody rb;


    public float span = 5.0f;
    public float power = 2000;
    float tmpSpan = 0;
    public Vector3 center;
    public Vector3 zurashi;


    void Start()
    {
        //rb = GetComponent<RigidTakahara>();
        boss = GameObject.Find("Boss");
        canvas = GameObject.Find("Canvas");
        center =  boss.transform.position;
        bull =(GameObject) Resources.Load("EnemyBullet");
        targetImage = (GameObject)Resources.Load("TargetUI");

    }

    // Update is called once per frame
    void Update()
    {
        center = boss.transform.position;
        tmpSpan += Time.deltaTime;
        if(span<tmpSpan){
            tmpSpan = 0;
            BulletMake();
        }



    }
    public void BulletMake(){
        for (int i =0; i < bullNum; i++)
        {
            float x = Random.Range(xRange[0], xRange[1]);
            float y = Random.Range(yRange[0], yRange[1]);
            Vector3 where = new Vector3(x, y, zRange);
            Vector3 tmp = new Vector3(0, 0, zRange);
            // GameObject bullMade = Instantiate(bull, where, Quaternion.identity);
            GameObject imageMade = Instantiate(targetImage);
            imageMade.GetComponent<TargetUI>().targetPosition=where;
            imageMade.transform.SetParent(canvas.transform, false);
            /*GameObject としてインスタンス化した法の情報を使うようにしないとprefabの情報を利用することに
            なるので注意が必要なのである*/

            GameObject bullMade=Instantiate(bull, center+zurashi, Quaternion.identity);
            bullMade.GetComponent<BossBulletController>().targetUI = imageMade;
            bullMade.GetComponent<BossBulletController>().startPoint = center + zurashi;
            Vector3 direction = where - (center + zurashi);
            Shoot(bullMade, direction);

        }
    }
       void Shoot(GameObject bullMade,Vector3 direction){
        rb = bullMade.GetComponent<Rigidbody>();
      //  Debug.Log("direction:" + direction.normalized);
      //  yield return new WaitForSeconds(1.0f);
        rb.AddForce(direction.normalized * power);
       // Debug.Log("hurufhruhfurhfur");


    }
     public void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(center+zurashi, radius);

    }
}
