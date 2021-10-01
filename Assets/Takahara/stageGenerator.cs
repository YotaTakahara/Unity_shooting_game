using UnityEngine;

public class stageGenerator : MonoBehaviour
{
    public GameObject airplane;
    public GameObject terrain;
    private float count = 0;

    void Update()
    {
        float where = airplane.transform.position.z;
        if (100 + where - (250 + count * 500) > 0)
        {
            Instantiate(terrain, new Vector3(-500f, -0.3f, count * 500f), Quaternion.identity);
            count += 1;
        }
    }
    
    
    
    
    
}