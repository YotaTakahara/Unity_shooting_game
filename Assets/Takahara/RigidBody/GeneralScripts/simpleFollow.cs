using UnityEngine;

public class simpleFollow : MonoBehaviour
{
    public GameObject player;

    public float followSpeed;

    private Vector3 diff;
    private Quaternion rot;

    // Start is called before the first frame update

    void Awake()
    {
        player = GameObject.Find("AirPlane");
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 13);
    }
    void Start()
    {
        // this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 5, player.transform.position.z - 13);
        diff = player.transform.position - transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // transform.position = Vector3.Lerp(transform.position, player.transform.position - diff,
        //     followSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, player.transform.position - diff,
            followSpeed * Time.deltaTime);
        // rot = Quaternion.LookRotation(diff);

        // transform.rotation = rot;

    }
}