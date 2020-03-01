using UnityEngine;

public class WTriangle
{
    public Vector3 a, b, c;
    
    public WTriangle(Vector3 a, Vector3 b, Vector3 c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    public WTriangle(Vector3 a, Vector3 b, Vector3 c, Vector3 worldPos)
    {
        this.a = a - worldPos;
        this.b = b - worldPos;
        this.c = c - worldPos;
    }



    public override string ToString()
    {
        return a + "," + b + "," + c;
    }

}
