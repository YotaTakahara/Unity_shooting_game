using UnityEngine;

public interface ISphere
{
    Vector3 Center { get; }
    float Radius { get; }
    Vector3 WorldCenter { get; }
}
public interface ICube
{
    Vector3 Center { get; }
    float X { get; }
    float Y { get; }
    float Z { get; }
    Vector3 WorldCenter { get; }
}