using UnityEngine;

public class Shakyo : MonoBehaviour
{
    public enum Direction
    {
        XAxis = 0,
        YAxis = 1,
        ZAxis = 2,
    }

    [SerializeField] private float radius = 0.5f;
    [SerializeField] private Vector3 center;
    [SerializeField] private Direction direction = Direction.YAxis;
    [SerializeField] private float height = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}