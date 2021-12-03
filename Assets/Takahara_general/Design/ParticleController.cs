using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : ControllerBase
{
    [SerializeField] private ParticleSystem partSystem;
    ParticleSystem.ShapeModule shape;

    public Vector3 zurashi = new Vector3(0, 0, 10);
    public float follow;
    private Vector3 diff;

    // Update is called once per frame
    void Start()
    {
        transform.position = player.transform.position + zurashi;
        partSystem = GetComponent<ParticleSystem>();
        shape = partSystem.shape;
        //  diff = player.transform.position.normalized
        StartCoroutine(ParticleChange(1.5f, 50f));

    }
    void FixedUpdate()
    {
        transform.position = new Vector3(0, 0, player.transform.position.z) + zurashi;// Vector3.Lerp(transform.position, player.transform.position - diff, followSpeed * Time.deltaTime);

    }
    IEnumerator ParticleChange(float size, float radius)
    {
        yield return new WaitForSeconds(5.0f);
        var main = partSystem.main;
        main.startSize = size;
        shape.radius = radius;


    }
}
