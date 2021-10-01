using UnityEngine;

public class bulletController : MonoBehaviour
{
    public float abs;
    GameObject airPlane;
    private Vector3 latestPos;
    public float num;
    public float span = 0.5f;
    private float delta = 0;
    public float range;


    void Start()
    {
        latestPos = transform.position;
    }

    void Update()
    {
        Vector3 diff = transform.position - latestPos;
        if (diff.magnitude > range)
        {
            Destroy(gameObject);
        }
        //transform.Translate(0, 0, 0.2f);
        // Vector3 a = airPlane.transform.position;
        // Vector3 diff = a - latestPos;
        // delta += Time.deltaTime;
        // if (span < delta)
        // {
        //     latestPos = a;
        //     delta = 0;
        // }
        //
        //
        // Debug.Log("LatestPos" + latestPos);
        // Debug.Log("now" + a);
        // Debug.Log("diff" + diff.normalized);
        //
        // transform.Translate(diff.normalized * num);
    }
}