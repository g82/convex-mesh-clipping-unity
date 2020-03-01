using UnityEngine;
using System.Collections.Generic;

public class WMesh
{
    List<WTriangle> bodyTris;
    List<WTriangle> capTris;

    public List<WTriangle> GetBodyTris()
    {
        return bodyTris;
    }
    
    public WMesh(Mesh unityMesh)
    {
        bodyTris = new List<WTriangle>();        
        int[] tris = unityMesh.GetTriangles(0);
        Vector3[] vertices = unityMesh.vertices;
        for (int i = 0; i < tris.Length; i += 3)
        {
            WTriangle tri = new WTriangle(
                vertices[tris[i]], 
                vertices[tris[i + 1]], 
                vertices[tris[i + 2]]);
            bodyTris.Add(tri);
        }
    }

    public WMesh(List<WTriangle> bodyTris, List<WTriangle> capTris)
    {
        this.bodyTris = bodyTris;
        this.capTris = capTris;
    }
    

    public Mesh ToUnityMesh(string meshName)
    {
        Mesh mesh = new Mesh();
        mesh.name = meshName;
        mesh.subMeshCount = 2;

        List<WTriangle> allTriangles = new List<WTriangle>(bodyTris);

        if (capTris != null) allTriangles.AddRange(capTris);


        // 1. Set All Vertices
        int vertCount = allTriangles.Count * 3;

        Vector3[] vertices = new Vector3[vertCount];
        int vertIdx = 0;

        for (int i = 0; i < allTriangles.Count; i++)
        {
            WTriangle tri = allTriangles[i];
            vertices[vertIdx] = tri.a;
            vertices[vertIdx + 1] = tri.b;
            vertices[vertIdx + 2] = tri.c;

            vertIdx += 3;
        }

        mesh.vertices = vertices;


        // 2. Set Body Triangle : Submesh 0
        int bodyArrLen = bodyTris.Count * 3;

        int[] bodyArr = new int[bodyArrLen];

        for (int i = 0; i < bodyArrLen; i += 3)
        {
            bodyArr[i] = i;
            bodyArr[i + 1] = i + 1;
            bodyArr[i + 2] = i + 2;
        }

        mesh.SetTriangles(bodyArr, 0);

        // 3. Set Cap Triangle : Submesh 1
        int capStartIdx = bodyArrLen;

        int capArrLen = capTris.Count * 3;

        int[] capArr = new int[capArrLen];

        for (int i = 0; i < capArrLen; i += 3)
        {
            capArr[i] = capStartIdx + i;
            capArr[i + 1] = capStartIdx + i + 1;
            capArr[i + 2] = capStartIdx + i + 2;
        }

        mesh.SetTriangles(capArr, 1);


        // 4. Finish                                    
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        return mesh;
    }

}
