using UnityEngine;

public class simpleFollow : MonoBehaviour
{
    public GameObject target;

    public float followSpeed;

    private Vector3 diff;
    private Quaternion rot;

    // Start is called before the first frame update

    void Awake()
    {
        target = GameObject.Find("AirPlane");
        this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 5, target.transform.position.z - 13);
    }
    void Start()
    {
        // this.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 5, target.transform.position.z - 13);
        diff = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = Vector3.Lerp(transform.position, target.transform.position - diff,
        //     followSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, target.transform.position - diff,
            followSpeed * Time.deltaTime);
        // rot = Quaternion.LookRotation(diff);

        // transform.rotation = rot;

    }
}