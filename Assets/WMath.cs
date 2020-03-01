using UnityEngine;

public class WMath
{
    public static bool InFront(float distance)
    {
        return distance > Mathf.Epsilon;
    }

    public static bool Behind(float distance)
    {
        return distance < -Mathf.Epsilon;
    }

    //Intersect = Lerp
    public static Vector3 Intersect(Vector3 a, Vector3 b, float d1, float d2)
    {
        return a + (d1 / (d1 - d2)) * (b - a);
    }
}

