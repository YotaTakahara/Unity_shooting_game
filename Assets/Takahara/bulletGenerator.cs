using UnityEngine;

public class bulletGenerator : MonoBehaviour
{
    public bulletController bull;
    public bulletController bullNext;
    public float count = 5;
    public GameObject airPlane;
    public float span = 1.0f;
    float delta = 0.0f;
    public float power;

    void Start()
    {
        airPlane = GameObject.Find("AirPlane");
    }


    void Update()
    {
        delta += Time.deltaTime;
        if (span <= delta)
        {
            Vector3 firstPosition = airPlane.transform.position;
            delta = 0;
            air hito = airPlane.GetComponent<air>();

            if (hito.point < count)
            {
                bulletController bullet = Instantiate(bull, firstPosition, Quaternion.identity);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(airPlane.transform.forward * power);
            }
            else
            {
                bulletController bulletNe = Instantiate(bullNext, firstPosition, Quaternion.identity);
                Rigidbody rb = bulletNe.GetComponent<Rigidbody>();
                rb.AddForce(airPlane.transform.forward * power);
            }


            // bullet.airPlane = airPlane;
        }
    }
}