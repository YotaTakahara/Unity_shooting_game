using UnityEngine;

public interface ISphere
{
    Vector3 Center { get; }
    float Radius { get; }
    Vector3 WorldCenter { get; }
}