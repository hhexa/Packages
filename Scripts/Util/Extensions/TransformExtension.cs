using UnityEngine;

/*
    Credit to Unity3D College for awsome tutorials on Extensions
    https://unity3d.college/2016/11/22/unity-extension-methods/
    https://www.youtube.com/watch?v=S8YfVlffSSA
 */

public static class TransformExtension
{
    private const float DOT_THREASHOLD = 0.5f;

    public static bool IsFacingTarget(this Transform source, Transform target)
    {
        Vector3 vectorToTarget = target.position = source.position;
        vectorToTarget.Normalize();

        float dot = Vector3.Dot(source.forward, vectorToTarget);
        return dot >= DOT_THREASHOLD;
    }

    public static void LookAtY(this Transform source, Transform target)
    {
        var lookPos = target.position - source.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        source.rotation = rotation;
    }

    public static void LookAtY(this Transform source, Vector3 point)
    {
        var lookPos = point - source.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        source.rotation = rotation;
    }

    public static Vector3 With(this Transform source, float? x = null, float? y = null, float? z = null)
    {
        return new Vector3(x ?? source.position.x, y ?? source.position.y, z ?? source.position.z);
    }

    public static Vector3 Flat(this Transform source)
    {
        return new Vector3(source.position.x, 0, source.position.z);
    }

    public static Vector3 DirectionTo(this Transform source, Transform destination)
    {
        return source.position.DirectionTo(destination.position);
    }

    public static Vector3 DirectionTo(this Transform source, Vector3 destination)
    {
        return source.position.DirectionTo(destination);
    }

    //From: https://github.com/foolmoron/PicosRapture/blob/master/Assets/Scripts/Extensions/Vector3Extensions.cs
    //Credit to this guy github.com/foolmoron for making these extensions public

    public static Vector2 to2(this Vector3 vector)
    {
        return vector;
    }

    public static Vector3 withX(this Vector3 vector, float x)
    {
        return new Vector3(x, vector.y, vector.z);
    }

    public static Vector3 withY(this Vector3 vector, float y)
    {
        return new Vector3(vector.x, y, vector.z);
    }

    public static Vector3 withZ(this Vector3 vector, float z)
    {
        return new Vector3(vector.x, vector.y, z);
    }

    public static Vector3 plusX(this Vector3 vector, float plusX)
    {
        return new Vector3(vector.x + plusX, vector.y, vector.z);
    }

    public static Vector3 plusY(this Vector3 vector, float plusY)
    {
        return new Vector3(vector.x, vector.y + plusY, vector.z);
    }

    public static Vector3 plusZ(this Vector3 vector, float plusZ)
    {
        return new Vector3(vector.x, vector.y, vector.z + plusZ);
    }

    public static Vector3 timesX(this Vector3 vector, float timesX)
    {
        return new Vector3(vector.x * timesX, vector.y, vector.z);
    }

    public static Vector3 timesY(this Vector3 vector, float timesY)
    {
        return new Vector3(vector.x, vector.y * timesY, vector.z);
    }

    public static Vector3 timesZ(this Vector3 vector, float timesZ)
    {
        return new Vector3(vector.x, vector.y, vector.z * timesZ);
    }
}