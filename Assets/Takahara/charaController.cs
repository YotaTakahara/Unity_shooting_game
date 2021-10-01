using UnityEngine;

public class charaController : MonoBehaviour
{
    public float speed;


    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical"), 0.2f);
    }
}