using UnityEngine;

public class BulletCollider : MonoBehaviour
{
    public GameObject[] objectsRed;
    public GameObject[] objectsBlue;
    public GameObject fire;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        objectsRed = GameObject.FindGameObjectsWithTag("Monster");
        objectsBlue = GameObject.FindGameObjectsWithTag("MonsterBlue");
        foreach (GameObject monRed in objectsRed)
        {
            Vector3 bull = transform.position;
            Vector3 ene = monRed.transform.position;
            float sizeMon = monRed.transform.localScale.x;
            float sizeBull = transform.localScale.x;
            // Debug.Log("sizeBUll" + sizeBull);
            // Debug.Log("sizeEne" + sizeMon);

            float length = (bull - ene).magnitude;
            // Debug.Log("length" + length);


            if (length < sizeMon + sizeBull)
            {
                Destroy(monRed.gameObject);
                Destroy(gameObject);
                //Debug.Log("うまく破壊できた");
                Instantiate(fire, monRed.transform.position, Quaternion.identity);
            }
        }
    }
}