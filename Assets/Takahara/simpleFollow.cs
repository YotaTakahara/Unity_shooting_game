using UnityEngine;

public class simpleFollow : MonoBehaviour
{
    public GameObject target;

    public float followSpeed;

    private Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        diff = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = Vector3.Lerp(transform.position, target.transform.position - diff,
        //     followSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, target.transform.position - diff,
            followSpeed * Time.deltaTime);
    }
}