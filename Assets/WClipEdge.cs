using UnityEngine;

public class WClipEdge
{
    public Vector3 start, end;

    public WClipEdge(Vector3 start, Vector3 end)
    {
        this.start = start;
        this.end = end;
    }

    public WClipEdge(Vector3 start, Vector3 end, Vector3 worldPos)
    {
        this.start = start - worldPos;
        this.end = end - worldPos;
    }
}

