using UnityEngine;

public class destroyCreature : MonoBehaviour
{
    public GameObject fire;
    GameObject airr;
    air airScript;

    // void OnTriggerEnter(Collider other)
    // {
    //     Instantiate(fire, transform.position, Quaternion.identity);
    //     if (gameObject.tag == "MonsterBlue")
    //     {
    //         Debug.Log("blue!!!!!!!!!!!!");
    //         Vector3 lossy = transform.lossyScale;
    //         Debug.Log("monsterBlueの大きさや" + lossy);
    //     }
    //
    //     if (gameObject.tag == "Monster")
    //     {
    //         Debug.Log("red!!!!!!!!!!");
    //         Vector3 lossy = transform.lossyScale;
    //         Debug.Log("monsterRedの大きさや" + lossy);
    //         Debug.Log("グローバル系について" + lossy.x);
    //         Debug.Log("ローカル系について" + transform.localScale.x);
    //     }
    //
    //     Destroy(gameObject);
    //     airr = GameObject.Find("AirPlane");
    //     airScript = airr.GetComponent<air>();
    //     airScript.point += 1;
    //     Debug.Log(airScript.point);
    // }
}